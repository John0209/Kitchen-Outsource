using Kitchen.Application.Models.Responses.Forum;
using MediatR;

namespace Kitchen.Application.Models.Requests.Forum;

public class GetPostDetailRequest : IRequest<GetPostDetailResponse>
{
    public int PostId { get; set; }
}