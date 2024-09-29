using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Infrastructure.Repositories.IRepositories;
using RecipeCategoryEnum.Entities;

namespace RecipeCategoryEnum.Repositories.IRepositories;

public interface IAdminRepository : IBaseRepository<Admin>
{
    public Admin? CheckLogin(AdminLoginRequest request);
}