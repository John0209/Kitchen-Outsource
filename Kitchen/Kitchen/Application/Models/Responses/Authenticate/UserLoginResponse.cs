namespace Kitchen.Application.Models.Responses.Authenticate;

public class UserLoginResponse
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsMember { get; set; }
}