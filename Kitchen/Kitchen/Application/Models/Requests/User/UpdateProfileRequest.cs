using System.Text.Json.Serialization;
using Actor.Infrastructure.Enum;
using MediatR;

namespace Kitchen.Application.Models.Requests.User;

public class UpdateProfileRequest : IRequest<Unit>
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    
    public GenderType Gender { get; set; }
}