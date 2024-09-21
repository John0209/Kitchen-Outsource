using Kitchen.Application.Models.Responses.Authenticate;
using Kitchen.Application.Models.Responses.User;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Mapper;

public static class UserMapper
{
    public static UserLoginResponseDto UserToLoginDtoResponse(User dto) => new UserLoginResponseDto()
    {
        UserId = dto.Id,
        Name = dto.UserName,
        Email = dto.Email
    };

    public static RegisterResponseDto UserToRegisterDtoResponse(User dto) => new RegisterResponseDto()
    {
        UserId = dto.Id,
        Name = dto.UserName,
        Email = dto.Email,
        Status = dto.Status
    };

    public static GetUserDetailResponseDto UserToUserDetailResponseDto(User dto) => new GetUserDetailResponseDto()
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