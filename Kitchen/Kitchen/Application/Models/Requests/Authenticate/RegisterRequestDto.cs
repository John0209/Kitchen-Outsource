using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Actor.Infrastructure.Enum;
using Kitchen.Application.Models.Responses.Authenticate;
using MediatR;

namespace Kitchen.Application.Models.Requests.Authenticate;

public class RegisterRequestDto : IRequest<RegisterResponseDto>
{
    public required string Name { get; set; }
    [DataType(DataType.EmailAddress)] public required string Email { get; set; }
    public required string Password { get; set; }
}