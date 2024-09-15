using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Kitchen.Application.Models.Requests;

public class VerifyDtoRequest : IRequest<bool>
{
    [DataType(DataType.EmailAddress)] public required string Email { get; set; }
    public required int VerifyCode { get; set; }
}