using Application.ErrorHandlers;
using Kitchen.Infrastructure.Repositories.IRepositories;
using RecipeCategoryEnum.DbContext;
using RecipeCategoryEnum.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(AppDbContext context, IUserRepository userRepository, IAdminRepository adminRepository, IRecipeRepository recipeRepository, IPostRepository postRepository,
        ICommentRepository commentRepository)
    {
        _context = context;
        UserRepository = userRepository;
        AdminRepository = adminRepository;
        RecipeRepository = recipeRepository;
        PostRepository = postRepository;
        CommentRepository = commentRepository;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    private readonly AppDbContext _context;

    public IUserRepository UserRepository { get; }
    public IAdminRepository AdminRepository { get; }
    public IRecipeRepository RecipeRepository { get; }
    public IPostRepository PostRepository { get; }
    public ICommentRepository CommentRepository { get; }

    public async Task<int> SaveChangeAsync()
    {
        //Handle concurrency update
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            foreach (var entry in ex.Entries)
            {
                var databaseValues = await entry.GetDatabaseValuesAsync();

                if (databaseValues != null)
                {
                    // Refresh original values to bypass next concurrency check
                    entry.OriginalValues.SetValues(databaseValues);
                }
                else
                {
                    // Handle entity not found in the database
                    throw new NotFoundException("Entity not found in the database.");
                }
            }

            // Try saving changes again after resolving conflicts
            return await _context.SaveChangesAsync();
        }
    }
}