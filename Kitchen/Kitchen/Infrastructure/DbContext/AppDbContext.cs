using Actor.Infrastructure.Enum;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Enum;
using Microsoft.EntityFrameworkCore;
using RecipeCategoryEnum.Entities;
using DietType = Kitchen.Infrastructure.Entities.DietType;

namespace Kitchen.Infrastructure.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Tutorial> Tutorials { get; set; }
    public virtual DbSet<PostCategory> PostCategories { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<DietType> DietTypes { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Expert> Experts { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostCategory>().HasData(
            new PostCategory() { Id = 1, CategoryName = "Kitchen Story" },
            new PostCategory() { Id = 2, CategoryName = "Handbooks And tip" },
            new PostCategory() { Id = 3, CategoryName = "Knowledge" },
            new PostCategory() { Id = 4, CategoryName = "DeliciousFood" },
            new PostCategory() { Id = 5, CategoryName = "Explore" }
        );

        modelBuilder.Entity<DietType>().HasData(
            new DietType() { Id = 1, DietName = "Daily" },
            new DietType() { Id = 2, DietName = "Vegetarian" },
            new DietType() { Id = 3, DietName = "Dietary" },
            new DietType() { Id = 4, DietName = "Exercise" }
        );

        modelBuilder.Entity<Membership>().HasData(
            new Membership() { Id = 1, Price = 80000, ValidityPeriod = ValidityPeriodType.Week },
            new Membership() { Id = 2, Price = 150000, ValidityPeriod = ValidityPeriodType.Month },
            new Membership() { Id = 3, Price = 1600000, ValidityPeriod = ValidityPeriodType.Year }
        );

        modelBuilder.Entity<Admin>().HasData(
            new Admin() { Id = 1, Name = "John Administrator", Account = "admin", Password = "12345" }
        );

        modelBuilder.Entity<Expert>().HasData(
            new Expert() { Id = 1, Name = "John Expert", Email = "expert@gmail.com", Password = "12345" }
        );

        modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1, UserName = "John Vũ", Email = "long88ka@gmail.com", Password = "12345",
                CreateDate = DateTime.Now, PhoneNumber = "0397528860", Status = UserStatus.Verified
            }
        );
    }
}