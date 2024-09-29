using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Forum;
using Kitchen.Application.Models.Responses.Forum;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Forum;

public class GetPostDetailHandler : IRequestHandler<GetPostDetailRequest, GetPostDetailResponse>
{
    private readonly IUnitOfWork _unit;

    public GetPostDetailHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<GetPostDetailResponse> Handle(GetPostDetailRequest request, CancellationToken cancellationToken)
    {
        var post = await _unit.PostRepository.GetByIdAsync(request.PostId) ?? throw new BadRequestException("PostId is not found");

        return PostsMapper.PostToPostDetailResponseDto(post);
    }
}