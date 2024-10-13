using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Enum;
using Kitchen.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(AppDbContext context) : base(context)
    {
    }

    public override Task<Transaction?> GetByIdAsync(int id, bool disableTracking = false)
    {
        return DbSet.Include(x => x.User).Include(x => x.Membership)
            .FirstOrDefaultAsync(x => x.Id == id && x.Status == TransactionStatus.Processing);
    }

    public override Task<List<Transaction>> GetAsync()
    {
        return DbSet.Include(x => x.User).Include(x => x.Membership).ToListAsync();
    }

    public Task<Transaction?> GetTransactionByCode(string code)
    {
        return DbSet.Include(x => x.User)
            .Include(x => x.Membership)
            .FirstOrDefaultAsync(x => x.TransactionCode == code && x.Status == TransactionStatus.Processing);
    }

    public Task<Transaction?> GetLastTransaction()
    {
        return DbSet.OrderByDescending(x=> x.Id)
            .FirstOrDefaultAsync(x => x.Status == TransactionStatus.Processing);
    }
}