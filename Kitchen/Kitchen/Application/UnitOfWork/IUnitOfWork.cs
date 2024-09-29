using Kitchen.Infrastructure.Repositories.IRepositories;
using RecipeCategoryEnum.Repositories.IRepositories;

namespace Kitchen.Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IAdminRepository AdminRepository { get; }
    IRecipeRepository RecipeRepository { get; }
    IPostRepository PostRepository { get; }
    ICommentRepository CommentRepository { get; }
    IPlanRepository PlanRepository { get; }
    IExpertRepository ExpertRepository { get; }
    public Task<int> SaveChangeAsync();
}