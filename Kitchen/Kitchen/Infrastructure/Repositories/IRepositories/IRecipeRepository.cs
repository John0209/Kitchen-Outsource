using Kitchen.Application.Models.Requests.Recipe;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Interfaces.IRepositories;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    public Task<List<Recipe>> GetRecipesAsync(GetRecipeRequestDto dto);
}