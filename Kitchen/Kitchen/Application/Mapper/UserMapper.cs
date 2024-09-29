using Kitchen.Application.Models.Responses.Authenticate;
using Kitchen.Application.Models.Responses.User;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Mapper;

public static class UserMapper
{
    public static UserLoginResponse UserToLoginDtoResponse(User dto) => new UserLoginResponse()
    {
        UserId = dto.Id,
        Name = dto.UserName,
        Email = dto.Email
    };

    public static RegisterResponse UserToRegisterDtoResponse(User dto) => new RegisterResponse()
    {
        UserId = dto.Id,
        Name = dto.UserName,
        Email = dto.Email,
        Status = dto.Status
    };

    public static GetUserDetailResponse UserToUserDetailResponseDto(User dto) => new GetUserDetailResponse()
    {
        UserId = dto.Id,
        UserName = dto.UserName,
        PhoneNumber = dto.PhoneNumber,
        Email = dto.Email,
        PictureUrl = dto.Avarta,
        Address = dto.Address,
        DateOfBirth = DateUtils.FormatDateTimeToDateV1(dto.DateOfBirth),
        CreateDate = DateUtils.FormatDateTimeToDatetimeV1(dto.CreateDate),
        Gender = dto.Gender,
        Status = dto.Status
    };
}