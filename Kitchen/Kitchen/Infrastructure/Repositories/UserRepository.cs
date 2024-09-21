using Actor.Infrastructure.Enum;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.DbContext;
using RecipeCategoryEnum.Repositories;
using RecipeCategoryEnum.Repositories.IRepositories;

namespace Kitchen.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public User? CheckLogin(UserLoginRequestDto requestDto)
    {
        return DbSet
            .FirstOrDefault(x => x.Email == requestDto.Email && x.Password == requestDto.Password && x.Status == UserStatus.Verified);
    }

    public (User?, bool) CheckEmailExist(string email)
    {
        return (DbSet.FirstOrDefault(x => x.Email == email), DbSet.Any(x => x.Email == email));
    }

    public User? VerifyCode(string email, int code)
    {
        return DbSet.FirstOrDefault(x => x.Email == email && x.VerifyCode == code);
    }

    public override Task<User?> GetByIdAsync(int id, bool disableTracking = false)
    {
        return DbSet
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}