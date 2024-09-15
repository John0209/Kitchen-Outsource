// using Actor.Application.Models.Responses;
// using Actor.Application.Utils;
// using Actor.Infrastructure.Entities;
//
// namespace Actor.Application.Mapper;
//
// public static class UserMapper
// {
//     public static LoginDtoResponse UserToLoginDtoResponse(User dto) => new LoginDtoResponse()
//     {
//         UserId = dto.Id,
//         Name = dto.UserName,
//         PhoneNumber = dto.PhoneNumber,
//         Email = dto.Email,
//         CreateDate = DateUtils.FormatDateTimeToDatetimeV1(dto.CreateDate),
//         PictureUrl = dto.PictureUrl,
//         Role = dto.Role!.RoleName
//     };
//
//     public static RegisterDtoResponse UserToRegisterDtoResponse(User dto) => new RegisterDtoResponse()
//     {
//         UserId = dto.Id,
//         Name = dto.UserName,
//         Email = dto.Email,
//         Status = dto.Status
//     };
// }