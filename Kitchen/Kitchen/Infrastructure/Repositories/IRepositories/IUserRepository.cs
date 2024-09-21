using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Entities;
using RecipeCategoryEnum.Interfaces.IRepositories;

namespace RecipeCategoryEnum.Repositories.IRepositories;

public interface IUserRepository : IBaseRepository<User>
{
    public User? CheckLogin(UserLoginRequestDto requestDto);
    public (User?, bool) CheckEmailExist(string email);
    public User? VerifyCode(string email, int code);
}