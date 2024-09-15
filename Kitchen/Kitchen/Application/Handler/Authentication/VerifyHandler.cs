// using Actor.Application.ErrorHandlers;
// using Actor.Application.Models.Requests;
// using Actor.Application.UnitOfWork;
// using Actor.Infrastructure.Enum;
// using Application.ErrorHandlers;
// using MediatR;
//
// namespace Actor.Application.Handler.Authentication;
//
// public class VerifyHandler : IRequestHandler<VerifyDtoRequest, bool>
// {
//     private readonly IUnitOfWork _unit;
//
//     public VerifyHandler(IUnitOfWork unit)
//     {
//         _unit = unit;
//     }
//
//     public async Task<bool> Handle(VerifyDtoRequest request, CancellationToken cancellationToken)
//     {
//         var user = _unit.UserRepository.VerifyCode(request.Email, request.VerifyCode) ??
//                    throw new BadRequestException("Incorrect verification code");
//
//         user.Status = UserStatus.Verified;
//         _unit.UserRepository.Update(user);
//         var result = await _unit.SaveChangeAsync();
//         if (result > 0) return true;
//
//         throw new NotImplementException("Add user information into DB Failed");
//     }
// }