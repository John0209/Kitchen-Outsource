using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface IExpertRepository : IBaseRepository<Expert>
{
    public Expert? CheckLogin(ExpertLoginRequest request);
}