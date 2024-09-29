using MediatR;

namespace Kitchen.Application.Models.Requests.Authenticate;

public class PassChangeRequest : IRequest<Unit>
{
    public int UserId { get; set; }
    public string Password { get; set; } = string.Empty;
}