using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Repositories.IRepositories;

namespace Kitchen.Infrastructure.Repositories;

public class ActorRepository : BaseRepository<Ingredient>, IActorRepository
{
    public ActorRepository(AppDbContext context) : base(context)
    {
    }
}