using Application.ErrorHandlers;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Application.UnitOfWork;
using Kitchen.Application.Utils;
using MediatR;

namespace Kitchen.Application.Handler.Authentication;

public class RecoverHandler : IRequestHandler<RecoverRequest, Unit>
{
    private readonly IUnitOfWork _unit;

    public RecoverHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<Unit> Handle(RecoverRequest request, CancellationToken cancellationToken)
    {
        var (user, isEmailExist) = _unit.UserRepository.CheckEmailExist(request.Email);
        if (!isEmailExist) throw new BadRequestException("Email has not existed in DB");

        if (user == null) throw new ConflictException("User information is null");

        user.Password = StringUtils.GenerateRandomNumberString(6);

        _unit.UserRepository.Update(user);
        if (await _unit.SaveChangeAsync() > 0)
        {
            EmailUtils.SendNewPasswordToEmail(user);
            return Unit.Value;
        }

        throw new NotFoundException("Update user password is failed");
    }
}