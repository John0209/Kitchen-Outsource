using Kitchen.Application.Models.Requests.Authenticate;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface IPostRepository : IBaseRepository<Post>
{
    Task<List<Post>> GetPosts(int categoryId);
}