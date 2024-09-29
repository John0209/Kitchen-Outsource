using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Repositories.IRepositories;
using RecipeCategoryEnum.Entities;

namespace RecipeCategoryEnum.Repositories.IRepositories;

public interface IUserRepository : IBaseRepository<User>
{
    public User? CheckLogin(UserLoginRequest request);
    public (User?, bool) CheckEmailExist(string email);
    public User? VerifyCode(string email, int code);
}