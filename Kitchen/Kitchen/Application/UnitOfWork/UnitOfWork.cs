// using Actor.Infrastructure.DbContext;
// using Actor.Infrastructure.Interfaces.IRepositories;
// using Actor.Infrastructure.Repositories.IRepositories;
// using Application.ErrorHandlers;
// using Microsoft.EntityFrameworkCore;
//
// namespace Actor.Application.UnitOfWork;
//
// public class UnitOfWork : IUnitOfWork
// {
//     public UnitOfWork(AppDbContext context, IUserRepository userRepository, IDirectorRepository directorRepository, IActorRepository actorRepository)
//     {
//         _context = context;
//         UserRepository = userRepository;
//         DirectorRepository = directorRepository;
//         ActorRepository = actorRepository;
//     }
//
//     public void Dispose()
//     {
//         throw new NotImplementedException();
//     }
//
//     private readonly AppDbContext _context;
//
//     public IUserRepository UserRepository { get; }
//     public IDirectorRepository DirectorRepository { get; }
//     public IActorRepository ActorRepository { get; }
//
//     public async Task<int> SaveChangeAsync()
//     {
//         //Handle concurrency update
//         try
//         {
//             return await _context.SaveChangesAsync();
//         }
//         catch (DbUpdateConcurrencyException ex)
//         {
//             foreach (var entry in ex.Entries)
//             {
//                 var databaseValues = await entry.GetDatabaseValuesAsync();
//
//                 if (databaseValues != null)
//                 {
//                     // Refresh original values to bypass next concurrency check
//                     entry.OriginalValues.SetValues(databaseValues);
//                 }
//                 else
//                 {
//                     // Handle entity not found in the database
//                     throw new NotFoundException("Entity not found in the database.");
//                 }
//             }
//
//             // Try saving changes again after resolving conflicts
//             return await _context.SaveChangesAsync();
//         }
//     }
// }