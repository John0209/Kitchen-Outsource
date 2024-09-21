using Kitchen.Application.Models.Requests.Forum;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Entities;
using RecipeCategoryEnum.Interfaces.IRepositories;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
    public Task<Comment?> GetComment(UserCommentRequestDto dto);
}