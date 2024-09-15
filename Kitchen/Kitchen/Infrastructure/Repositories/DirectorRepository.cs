using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Repositories.IRepositories;

namespace Kitchen.Infrastructure.Repositories;

public class DirectorRepository : BaseRepository<Comment>, IDirectorRepository
{
    public DirectorRepository(AppDbContext context) : base(context)
    {
    }
}