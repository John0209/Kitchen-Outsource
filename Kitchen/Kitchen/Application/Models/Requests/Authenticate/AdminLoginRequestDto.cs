using MediatR;

namespace Kitchen.Application.Models.Requests.Authenticate;

public class AdminLoginRequestDto : IRequest<string>
{
    public string Account { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}