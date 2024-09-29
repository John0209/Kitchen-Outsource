using Actor.Infrastructure.Enum;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.Entities;
using RecipeCategoryEnum.Repositories.IRepositories;

namespace RecipeCategoryEnum.Repositories;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(AppDbContext context) : base(context)
    {
    }

    public Admin? CheckLogin(AdminLoginRequest request)
    {
        return DbSet
            .FirstOrDefault(x => x.Account == request.Account && x.Password == request.Password);
    }
}