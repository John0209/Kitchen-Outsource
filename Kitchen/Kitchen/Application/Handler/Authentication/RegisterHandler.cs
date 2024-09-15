// using Actor.Application.ErrorHandlers;
// using Actor.Application.Mapper;
// using Actor.Application.Models.Requests;
// using Actor.Application.Models.Responses;
// using Actor.Application.UnitOfWork;
// using Actor.Application.Utils;
// using Actor.Infrastructure.Entities;
// using Actor.Infrastructure.Enum;
// using Application.ErrorHandlers;
// using MediatR;
//
// namespace Actor.Application.Handler.Authentication;
//
// public class RegisterHandler : IRequestHandler<RegisterDtoRequest, RegisterDtoResponse>
// {
//     private readonly IUnitOfWork _unit;
//
//     public RegisterHandler(IUnitOfWork unit)
//     {
//         _unit = unit;
//     }
//
//     public async Task<RegisterDtoResponse> Handle(RegisterDtoRequest request, CancellationToken cancellationToken)
//     {
//         var isEmailExist = _unit.UserRepository.CheckEmailExist(request.Email);
//         if (isEmailExist) throw new BadRequestException("Email has existed in DB");
//         var verifyCode = StringUtils.GenerateRandomNumber(6);
//
//         var wallet = new Wallet() { Money = 0 };
//
//         var user = new User()
//         {
//             UserName = request.Name,
//             Email = request.Email,
//             PhoneNumber = request.PhoneNumber,
//             Password = request.Password,
//             RoleId = (int)request.Role,
//             CreateDate = DateTime.Now,
//             Status = UserStatus.Waiting,
//             VerifyCode = int.Parse(verifyCode),
//             Wallet = wallet
//         };
//
//         switch (request.Role)
//         {
//             case RoleEnum.Director:
//                 user.Director = new Director() { ActionArea = request.Area };
//                 //await _unit.DirectorRepository.AddAsync(director);
//                 break;
//             case RoleEnum.Actor:
//                 user.Actor = new Infrastructure.Entities.Actor();
//                 //await _unit.ActorRepository.AddAsync(actor);
//                 break;
//         }
//
//         await _unit.UserRepository.AddAsync(user);
//         var result = await _unit.SaveChangeAsync();
//         if (result > 0)
//         {
//             SendVerifyCodeViaEmail(user);
//             return UserMapper.UserToRegisterDtoResponse(user);
//         }
//
//         throw new NotImplementException("Add user information into DB Failed");
//     }
//
//     private void SendVerifyCodeViaEmail(User user)
//     {
//         var title = "[FUTURE STAR] - Xác Minh Tài Khoản";
//         var content = "Xin chào " + user.UserName + "<br>" + "<br>" +
//                       "Future Star cảm ơn bạn đã đăng ký tài khoản tại website của chúng tôi." + "<br>" + "<br>" +
//                       "Bạn vui lòng nhập mã xác mình này vào ô xác nhận ở website để hoàn thành việc đăng ký tài khoản mới: "
//                       + "<strong>" + user.VerifyCode + "</strong><br><br>" +
//                       "Chúc bạn có một ngày làm việc hiệu quả!" + "<br>" + "<br>" + "Đội Ngũ Kỹ Thuật Future Star.";
//         EmailUtils.SendEmail(user.Email, title, content);
//     }
// }