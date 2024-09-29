using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Repositories.IRepositories;
using RecipeCategoryEnum.Entities;
using RecipeCategoryEnum.Repositories.IRepositories;

namespace Kitchen.Infrastructure.Repositories;

public class ExpertRepository : BaseRepository<Expert>, IExpertRepository
{
    public ExpertRepository(AppDbContext context) : base(context)
    {
    }

    public Expert? CheckLogin(ExpertLoginRequest request)
    {
        return DbSet
            .FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
    }
}