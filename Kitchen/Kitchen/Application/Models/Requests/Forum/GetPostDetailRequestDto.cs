using Kitchen.Application.Models.Responses.Forum;
using MediatR;

namespace Kitchen.Application.Models.Requests.Forum;

public class GetPostDetailRequestDto : IRequest<GetPostDetailResponseDto>
{
    public int PostId { get; set; }
}