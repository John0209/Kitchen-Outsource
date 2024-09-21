using Actor.Infrastructure.Enum;
using Application.ErrorHandlers;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Application.Models.Responses.Authenticate;
using Kitchen.Application.UnitOfWork;
using Kitchen.Application.Utils;
using RecipeCategoryEnum.Entities;
using MediatR;

namespace Kitchen.Application.Handler.Authentication;

public class RegisterHandler : IRequestHandler<RegisterRequestDto, RegisterResponseDto>
{
    private readonly IUnitOfWork _unit;

    public RegisterHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<RegisterResponseDto> Handle(RegisterRequestDto request, CancellationToken cancellationToken)
    {
        var isEmailExist = _unit.UserRepository.CheckEmailExist(request.Email);
        if (isEmailExist.Item2) throw new BadRequestException("Email has existed in DB");
        var verifyCode = StringUtils.GenerateRandomNumber(6);

        var user = new Infrastructure.Entities.User()
        {
            UserName = request.Name,
            Email = request.Email,
            Password = request.Password,
            CreateDate = DateTime.Now,
            Status = UserStatus.Waiting,
            VerifyCode = int.Parse(verifyCode),
        };

        await _unit.UserRepository.AddAsync(user);
        var result = await _unit.SaveChangeAsync();
        if (result > 0)
        {
           EmailUtils.SendVerifyCodeToEmail(user);
            return UserMapper.UserToRegisterDtoResponse(user);
        }

        throw new NotImplementException("Add user information into DB Failed");
    }
}