using Actor.Infrastructure.Enum;

namespace Kitchen.Application.Models.Responses.Authenticate;

public class RegisterResponse
{
    public int UserId { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public UserStatus Status { get; set; }
}