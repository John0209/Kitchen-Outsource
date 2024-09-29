using Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Application.Models.Responses.Authenticate;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Authentication;

public class AdminLoginHandler : IRequestHandler<AdminLoginRequest, string>
{
    private readonly IUnitOfWork _unit;

    public AdminLoginHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public Task<string> Handle(AdminLoginRequest request, CancellationToken cancellationToken)
    {
        var admin = _unit.AdminRepository.CheckLogin(request) ??
                    throw new UnauthorizedException("Account or password is wrong");

        return Task.FromResult(admin.Name);
    }
}