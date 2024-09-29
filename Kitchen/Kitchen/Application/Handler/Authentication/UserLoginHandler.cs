using Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Application.Models.Responses.Authenticate;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Authentication;

public class UserLoginHandler : IRequestHandler<UserLoginRequest, UserLoginResponse>
{
    private readonly IUnitOfWork _unit;

    public UserLoginHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var user = _unit.UserRepository.CheckLogin(request) ??
                   throw new UnauthorizedException("Email / password is wrong or account is not verified yet");

        return Task.FromResult(UserMapper.UserToLoginDtoResponse(user));
    }
}