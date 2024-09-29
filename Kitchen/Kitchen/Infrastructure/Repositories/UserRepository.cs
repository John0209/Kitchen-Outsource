using Actor.Infrastructure.Enum;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.Repositories;
using RecipeCategoryEnum.Repositories.IRepositories;

namespace Kitchen.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public User? CheckLogin(UserLoginRequest request)
    {
        return DbSet
            .FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password && x.Status == UserStatus.Verified);
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
        return DbSet.Include(x=> x.Plans)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
}