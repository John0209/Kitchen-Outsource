// using System.ComponentModel.DataAnnotations;
// using System.Text.Json.Serialization;
// using Actor.Application.Models.Responses;
// using Actor.Infrastructure.Enum;
// using MediatR;
//
// namespace Actor.Application.Models.Requests;
//
// public class RegisterDtoRequest : IRequest<RegisterDtoResponse>
// {
//     public required string Name { get; set; }
//     [DataType(DataType.EmailAddress)] public required string Email { get; set; }
//     public required string PhoneNumber { get; set; }
//     public required string Password { get; set; }
//     public string? Area { get; set; }
//     [JsonIgnore] public RoleEnum Role { get; set; }
// }