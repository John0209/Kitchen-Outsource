using Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.User;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.User;

public class UpdateProfileHandler : IRequestHandler<UpdateProfileRequest, Unit>
{
    private readonly IUnitOfWork _unit;

    public UpdateProfileHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<Unit> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
    {
        var user = await _unit.UserRepository.GetByIdAsync(request.UserId) ?? throw new NotFoundException("User information not found");

        user.UserName = request.UserName;
        user.PhoneNumber = request.PhoneNumber;
        user.Address = request.Address;
        user.DateOfBirth = request.DateOfBirth;
        user.Gender = request.Gender;
        
        _unit.UserRepository.Update(user);
        if (await _unit.SaveChangeAsync() < 0) throw new NotImplementException("Update user profile to DB failed");
        return Unit.Value;
    }
}