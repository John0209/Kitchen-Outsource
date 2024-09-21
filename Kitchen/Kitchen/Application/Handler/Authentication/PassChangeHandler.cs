using Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Authentication;

public class PassChangeHandler : IRequestHandler<PassChangeRequestDto, Unit>
{
    private readonly IUnitOfWork _unit;

    public PassChangeHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<Unit> Handle(PassChangeRequestDto request, CancellationToken cancellationToken)
    {
        var user = await _unit.UserRepository.GetByIdAsync(request.UserId) ?? throw new NotFoundException("Not found user information");

        user.Password = request.Password;

        _unit.UserRepository.Update(user);
        if (await _unit.SaveChangeAsync() < 0) throw new NotFoundException("Update user password to DB failed");
        return Unit.Value;
    }
}