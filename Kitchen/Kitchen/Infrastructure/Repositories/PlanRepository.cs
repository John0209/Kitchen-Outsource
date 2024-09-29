using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.Repositories;

namespace Kitchen.Infrastructure.Repositories;

public class PlanRepository : BaseRepository<Plan>, IPlanRepository
{
    public PlanRepository(AppDbContext context) : base(context)
    {
    }

    public Task<List<Plan>> GetPlansByUserId(int userId)
    {
        return DbSet.Where(x => x.UserId == userId).ToListAsync();
    }
}