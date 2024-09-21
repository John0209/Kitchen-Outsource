using Kitchen.Application.Models.Requests.Authenticate;
using RecipeCategoryEnum.Entities;
using RecipeCategoryEnum.Interfaces.IRepositories;

namespace RecipeCategoryEnum.Repositories.IRepositories;

public interface IAdminRepository : IBaseRepository<Admin>
{
    public Admin? CheckLogin(AdminLoginRequestDto requestDto);
}