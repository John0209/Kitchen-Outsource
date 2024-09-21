using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Kitchen.Application.Models.Requests.Authenticate;

public class RecoverRequestDto : IRequest<Unit>
{
    [DataType(DataType.EmailAddress)] public required string Email { get; set; }
}