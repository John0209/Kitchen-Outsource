using Kitchen.Application.Models.Requests.Forum;
using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.Entities;
using RecipeCategoryEnum.Repositories;

namespace Kitchen.Infrastructure.Repositories;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Comment?> GetComment(UserCommentRequest dto)
    {
        return DbSet.FirstOrDefaultAsync(x => x.PostId == dto.PostId && x.UserId == dto.UserId);
    }
}