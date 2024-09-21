using Kitchen.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.DbContext;
using RecipeCategoryEnum.Entities;
using RecipeCategoryEnum.Repositories;

namespace Kitchen.Infrastructure.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    public Task<List<Post>> GetPosts(int categoryId)
    {
        return DbSet.Include(x => x.PostCategory)
            .Include(x => x.Comments).Where(x => x.PostCategoryId == categoryId).ToListAsync();
    }

    public override Task<Post?> GetByIdAsync(int id, bool disableTracking = false)
    {
        return DbSet.Include(x => x.PostCategory)
            .Include(x => x.Poster)
            .Include(x => x.Comments)!.ThenInclude(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}