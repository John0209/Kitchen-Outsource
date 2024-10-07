using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
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
        return DbSet.Include(x => x.User).Include(x => x.Membership).FirstOrDefaultAsync(x => x.Id == id);
    }
}