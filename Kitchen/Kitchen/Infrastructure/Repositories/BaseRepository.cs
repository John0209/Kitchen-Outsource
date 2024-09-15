using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> DbSet;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
        DbSet = Context.Set<T>();
    }

    public virtual async Task<List<T>> GetAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public virtual async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entity)
    {
        await DbSet.AddRangeAsync(entity);
    }

    public virtual async Task<T?> GetByIdAsync(int id, bool disableTracking = false)
    {
        IQueryable<T> query = DbSet;

        if (disableTracking)
        {
            query.AsNoTracking();
        }

        return await query.Where(e => e.Id == id).FirstOrDefaultAsync();
    }
}