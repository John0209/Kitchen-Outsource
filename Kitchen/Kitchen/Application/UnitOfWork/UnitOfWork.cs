using Application.ErrorHandlers;
using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Repositories.IRepositories;
using RecipeCategoryEnum.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed = false;
    public UnitOfWork(AppDbContext context, IUserRepository userRepository, IAdminRepository adminRepository, IRecipeRepository recipeRepository, IPostRepository postRepository,
        ICommentRepository commentRepository, IPlanRepository planRepository, IExpertRepository expertRepository, ITransactionRepository transactionRepository)
    {
        _context = context;
        UserRepository = userRepository;
        AdminRepository = adminRepository;
        RecipeRepository = recipeRepository;
        PostRepository = postRepository;
        CommentRepository = commentRepository;
        PlanRepository = planRepository;
        ExpertRepository = expertRepository;
        TransactionRepository = transactionRepository;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Ngăn không cho garbage collector gọi finalizer
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Giải phóng các đối tượng quản lý
                _context?.Dispose();
            }

            // Giải phóng các đối tượng không quản lý nếu cần

            _disposed = true;
        }
    }

    private readonly AppDbContext _context;

    public IUserRepository UserRepository { get; }
    public IAdminRepository AdminRepository { get; }
    public IRecipeRepository RecipeRepository { get; }
    public IPostRepository PostRepository { get; }
    public ICommentRepository CommentRepository { get; }
    public IPlanRepository PlanRepository { get; }
    public IExpertRepository ExpertRepository { get; }
    public ITransactionRepository TransactionRepository { get; }

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