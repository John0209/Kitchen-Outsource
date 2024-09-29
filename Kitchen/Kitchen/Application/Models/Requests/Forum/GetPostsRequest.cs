using Kitchen.Application.Models.Responses.Forum;
using MediatR;

namespace Kitchen.Application.Models.Requests.Forum;

public class GetPostsRequest : IRequest<List<GetPostsResponse>>
{
    public int CategoryId { get; set; }
}