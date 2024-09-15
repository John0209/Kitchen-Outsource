using Kitchen.Application.Models.Requests;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Interfaces.IRepositories;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface IUserRepository : IBaseRepository<User>
{
    public User? CheckLogin(LoginDtoRequest dto);
    public bool CheckEmailExist(string email);
    public User? VerifyCode(string email, int code);
}