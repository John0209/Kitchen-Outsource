using Kitchen.Application.Models.Requests.Recipe;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.DbContext;
using RecipeCategoryEnum.Repositories;

namespace Kitchen.Infrastructure.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(AppDbContext context) : base(context)
    {
    }

    public override Task<Recipe?> GetByIdAsync(int id, bool disableTracking = false)
    {
        return DbSet.Include(x => x.Poster).Include(x => x.Ingredient)
            .Include(x => x.Tutorials)
            .Include(x => x.MealType).Include(x => x.RecipeCategory)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Recipe>> GetRecipesAsync(GetRecipeRequestDto dto)
    {
        return DbSet.Include(x=> x.MealType).Include(x=> x.RecipeCategory)
            .Where(x => x.MealTypeId == dto.MealTypeId && x.RecipeCategoryId == dto.RecipeCategoryId).ToListAsync();
    }
}