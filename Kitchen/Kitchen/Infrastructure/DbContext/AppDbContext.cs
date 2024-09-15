using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Enum;
using Microsoft.EntityFrameworkCore;
using MealType = Kitchen.Infrastructure.Entities.MealType;

namespace Kitchen.Infrastructure.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Tutorial> Tutorials { get; set; }
    public virtual DbSet<PostCategory> PostCategories { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<MealType> MealTypes { get; set; }
    public virtual DbSet<Admin> Admins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MealType>().HasData(
            new MealType() { Id = 1, TypeName = "Breakfast" },
            new MealType() { Id = 2, TypeName = "Lunch" },
            new MealType() { Id = 3, TypeName = "Dinner" },
            new MealType() { Id = 4, TypeName = "Dessert" }
        );

        modelBuilder.Entity<PostCategory>().HasData(
            new PostCategory() { Id = 1, CategoryName = "Kitchen" },
            new PostCategory() { Id = 2, CategoryName = "Handbooks" },
            new PostCategory() { Id = 3, CategoryName = "Knowledge" },
            new PostCategory() { Id = 4, CategoryName = "DeliciousFood" },
            new PostCategory() { Id = 5, CategoryName = "Explore" }
        );

        modelBuilder.Entity<RecipeCategory>().HasData(
            new RecipeCategory() { Id = 1, CategoryName = "Daily" },
            new RecipeCategory() { Id = 2, CategoryName = "Vegetarian" },
            new RecipeCategory() { Id = 3, CategoryName = "Dietary" },
            new RecipeCategory() { Id = 4, CategoryName = "Exercise" }
        );

        modelBuilder.Entity<Admin>().HasData(
            new Admin() { Id = 1, Name = "John Administrator", Account = "admin", Password = "12345" }
        );
    }
}