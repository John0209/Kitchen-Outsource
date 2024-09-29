using Actor.Infrastructure.Enum;
using Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Forum;
using Kitchen.Application.UnitOfWork;
using MediatR;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Handler.Forum;

public class CreatePostsHandler : IRequestHandler<CreatePostsRequest, Unit>
{
    private readonly IUnitOfWork _unit;

    public CreatePostsHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<Unit> Handle(CreatePostsRequest request, CancellationToken cancellationToken)
    {
        var post = new Post()
        {
            Title = request.Title,
            Content = request.Content,
            PostDate = DateTime.Now,
            Status = PostStatus.Opening,
            PosterId = request.PosterId,
            PostCategoryId = request.CategoryId
        };

        await _unit.PostRepository.AddAsync(post);
        if (await _unit.SaveChangeAsync() < 0) throw new NotImplementException("Create new post to DB failed");

        return Unit.Value;
    }
}