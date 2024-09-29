using Application.ErrorHandlers;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Forum;
using Kitchen.Application.UnitOfWork;
using Kitchen.Infrastructure.Entities;
using MediatR;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Handler.Forum;

public class UpdateCommentHandler : IRequestHandler<UserCommentRequest, Unit>
{
    private readonly IUnitOfWork _unit;

    public UpdateCommentHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<Unit> Handle(UserCommentRequest request, CancellationToken cancellationToken)
    {
        var user = await _unit.UserRepository.GetByIdAsync(request.UserId) ?? throw new BadRequestException("UserId is not found");
        var posts = await _unit.PostRepository.GetByIdAsync(request.PostId) ?? throw new BadRequestException("PostId is not found");

        var comment = await _unit.CommentRepository.GetComment(request);

        if (comment == null)
        {
            var commentDto = new Comment()
            {
                UserId = request.UserId,
                PostId = request.PostId,
                Content = request.Content,
                CommentDate = DateTime.Now
            };
            user.Comments?.Add(commentDto);
        }
        else
        {
            comment.Content = request.Content;
            comment.CommentDate = DateTime.Now;
        }

        _unit.UserRepository.Update(user);
        if (await _unit.SaveChangeAsync() < 0) throw new NotImplementException("Update comment to DB failed");

        return Unit.Value;
    }
}