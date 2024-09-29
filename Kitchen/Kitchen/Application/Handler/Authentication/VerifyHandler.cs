using Actor.Infrastructure.Enum;
using Application.ErrorHandlers;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Authentication;

public class VerifyHandler : IRequestHandler<VerifyRequest, Unit>
{
    private readonly IUnitOfWork _unit;

    public VerifyHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<Unit> Handle(VerifyRequest request, CancellationToken cancellationToken)
    {
        var user = _unit.UserRepository.VerifyCode(request.Email, request.VerifyCode) ??
                   throw new BadRequestException("Incorrect verification code");

        user.Status = UserStatus.Verified;
        _unit.UserRepository.Update(user);

        if (await _unit.SaveChangeAsync() > 0) return Unit.Value;

        throw new NotImplementException("Add user information into DB Failed");
    }
}