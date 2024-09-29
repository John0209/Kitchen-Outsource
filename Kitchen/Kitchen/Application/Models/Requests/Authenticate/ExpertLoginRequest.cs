using MediatR;

namespace Kitchen.Application.Models.Requests.Authenticate;

public class ExpertLoginRequest : IRequest<string>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}