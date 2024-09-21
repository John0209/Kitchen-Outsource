using Kitchen.Application.Models.Responses.Forum;
using MediatR;

namespace Kitchen.Application.Models.Requests.Forum;

public class GetPostsRequestDto : IRequest<List<GetPostsResponseDto>>
{
    public int CategoryId { get; set; }
}