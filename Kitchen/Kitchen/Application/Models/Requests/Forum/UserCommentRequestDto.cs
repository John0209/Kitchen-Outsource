using MediatR;

namespace Kitchen.Application.Models.Requests.Forum;

public class UserCommentRequestDto : IRequest<Unit>
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; } = string.Empty;
}