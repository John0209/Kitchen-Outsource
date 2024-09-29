using Kitchen.Application.Models.Requests.Recipe;
using Kitchen.Infrastructure.Entities;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    public Task<List<Recipe>> GetRecipesAsync(GetRecipeRequest dto);
    public Task<List<Recipe>> QuickSortAsync(QuickSortRecipeRequest dto);
}