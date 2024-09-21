using MediatR;

namespace Kitchen.Application.Models.Requests.Authenticate;

public class PassChangeRequestDto : IRequest<Unit>
{
    public int UserId { get; set; }
    public string Password { get; set; } = string.Empty;
}