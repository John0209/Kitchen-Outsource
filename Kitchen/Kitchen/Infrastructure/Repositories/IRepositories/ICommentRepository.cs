using Kitchen.Application.Models.Requests.Forum;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
    public Task<Comment?> GetComment(UserCommentRequest dto);
}