using Actor.Infrastructure.Enum;

namespace Kitchen.Application.Models.Responses.User;

public class GetUserDetailResponse
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PictureUrl { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public string? DateOfBirth { get; set; }
    public string? CreateDate { get; set; }
    public GenderType? Gender { get; set; }
    public UserStatus Status { get; set; }
}