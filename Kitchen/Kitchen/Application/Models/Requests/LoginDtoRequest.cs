using Kitchen.Application.Models.Responses;
using MediatR;

namespace Kitchen.Application.Models.Requests;

public class LoginDtoRequest: IRequest<LoginDtoResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}