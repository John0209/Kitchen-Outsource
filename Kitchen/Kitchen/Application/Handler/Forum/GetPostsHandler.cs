using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Forum;
using Kitchen.Application.Models.Responses.Forum;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Forum;

public class GetPostsHandler : IRequestHandler<GetPostsRequest, List<GetPostsResponse>>
{
    private readonly IUnitOfWork _unit;

    public GetPostsHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<GetPostsResponse>> Handle(GetPostsRequest request, CancellationToken cancellationToken)
    {
        var posts = await _unit.PostRepository.GetPosts(request.CategoryId);

        return PostsMapper.PostsToListGetPostsResponseDto(posts);
    }
}