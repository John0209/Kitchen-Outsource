using Kitchen.Infrastructure.Entities;

namespace Kitchen.Infrastructure.Repositories.IRepositories;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    public Task<Transaction?> GetTransactionByCode(string code);
    public Task<Transaction?> GetLastTransaction();
}