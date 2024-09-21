using System.ComponentModel.DataAnnotations;
using Kitchen.Application.Models.Responses.Authenticate;
using MediatR;

namespace Kitchen.Application.Models.Requests.Authenticate;

public class UserLoginRequestDto : IRequest<UserLoginResponseDto>
{
    [DataType(DataType.EmailAddress)] public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}