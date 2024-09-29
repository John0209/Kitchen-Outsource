using Kitchen.Application.Models.Requests.Recipe;
using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.Repositories;

namespace Kitchen.Infrastructure.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(AppDbContext context) : base(context)
    {
    }

    public override Task<Recipe?> GetByIdAsync(int id, bool disableTracking = false)
    {
        return DbSet.Include(x => x.Poster)
            .Include(x => x.Tutorials)
            .Include(x => x.DietType)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Recipe>> GetRecipesAsync(GetRecipeRequest dto)
    {
        return DbSet.Include(x => x.DietType)
            .Where(x => x.DietTypeId == dto.DietTypeId).ToListAsync();
    }

    public Task<List<Recipe>> QuickSortAsync(QuickSortRecipeRequest dto)
    {
        return DbSet.Include(x => x.DietType)
            .Where(x => x.DietTypeId == dto.DietTypeId && dto.RecipeId!.Contains(x.Id)).ToListAsync();
    }
}