using Kitchen.Infrastructure.Entities;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface IPlanRepository : IBaseRepository<Plan>
{
    public Task<List<Plan>> GetPlansByUserId(int userId);
}