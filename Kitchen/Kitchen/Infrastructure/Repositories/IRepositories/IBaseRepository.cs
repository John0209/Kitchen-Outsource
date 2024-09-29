using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAsync();
    void Update(T entity);
    void Delete(T entity);
    Task AddAsync(T entity);
    Task<T?> GetByIdAsync(int id, bool disableTracking = false);
    public Task AddRangeAsync(IEnumerable<T> entity);
    public void RemoveRange(IEnumerable<T> entity);
    public void UpdateRange(IEnumerable<T> entity);
}