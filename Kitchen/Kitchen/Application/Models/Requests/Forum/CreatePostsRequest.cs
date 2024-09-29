using MediatR;

namespace Kitchen.Application.Models.Requests.Forum;

public class CreatePostsRequest : IRequest<Unit>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int PosterId { get; set; }
    public int CategoryId { get; set; }
}