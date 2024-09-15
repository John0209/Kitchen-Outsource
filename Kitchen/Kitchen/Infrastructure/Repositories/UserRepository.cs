// using Kitchen.Infrastructure.Interfaces.IRepositories;
// using Kitchen.Application.Models.Requests;
// using Kitchen.Infrastructure.DbContext;
// using Kitchen.Infrastructure.Entities;
// using Kitchen.Infrastructure.Enum;
// using Kitchen.Infrastructure.Repositories.IRepositories;
// using Microsoft.EntityFrameworkCore;
//
// namespace Kitchen.Infrastructure.Repositories;
//
// public class UserRepository : BaseRepository<User>, IUserRepository
// {
//     public UserRepository(AppDbContext context) : base(context)
//     {
//     }
//
//     public User? CheckLogin(LoginDtoRequest dto)
//     {
//         return DbSet.Include(x => x.Role)
//             .FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password && x.Status == UserStatus.Verified);
//     }
//
//     public bool CheckEmailExist(string email)
//     {
//         return DbSet.Any(x => x.Email == email);
//     }
//
//     public User? VerifyCode(string email, int code)
//     {
//         return DbSet.FirstOrDefault(x => x.Email == email && x.VerifyCode == code);
//     }
// }