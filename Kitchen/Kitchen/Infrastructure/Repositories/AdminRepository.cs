using Actor.Infrastructure.Enum;
using Kitchen.Application.Models.Requests.Authenticate;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.DbContext;
using RecipeCategoryEnum.Entities;
using RecipeCategoryEnum.Repositories.IRepositories;

namespace RecipeCategoryEnum.Repositories;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(AppDbContext context) : base(context)
    {
    }

    public Admin? CheckLogin(AdminLoginRequestDto requestDto)
    {
        return DbSet
            .FirstOrDefault(x => x.Account == requestDto.Account && x.Password == requestDto.Password);
    }
}