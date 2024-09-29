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

        modelBuilder.Entity<Recipe>().HasData(
            new Recipe
            {
                Id = 1, Title = "Vegetable egg rolls",
                Description =
                    "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. " +
                    "Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. " +
                    "In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help " +
                    "strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs " +
                    "helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, " +
                    "limit frequent hunger, and reduce calories in the body.",
                PosterId = 1, Ingredient = "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", DietTypeId = 1,
                PostDate = DateTime.Now,
                FromPrice = 30000, ToPrice = 70000, FromCalories = 500, ToCalories = 800
            },
            new Recipe
            {
                Id = 2, Title = "Vegetable egg rolls",
                Description =
                    "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. " +
                    "Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. " +
                    "In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help " +
                    "strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs " +
                    "helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, " +
                    "limit frequent hunger, and reduce calories in the body.",
                PosterId = 1, Ingredient = "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", DietTypeId = 2,
                PostDate = DateTime.Now,
                FromPrice = 30000, ToPrice = 70000, FromCalories = 500, ToCalories = 800
            },
            new Recipe
            {
                Id = 3, Title = "Vegetable egg rolls",
                Description =
                    "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. " +
                    "Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. " +
                    "In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help " +
                    "strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs " +
                    "helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, " +
                    "limit frequent hunger, and reduce calories in the body.",
                PosterId = 1, Ingredient = "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", DietTypeId = 3,
                PostDate = DateTime.Now,
                FromPrice = 30000, ToPrice = 70000, FromCalories = 500, ToCalories = 800
            },
            new Recipe
            {
                Id = 4, Title = "Vegetable egg rolls",
                Description =
                    "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. " +
                    "Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. " +
                    "In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help " +
                    "strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs " +
                    "helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, " +
                    "limit frequent hunger, and reduce calories in the body.",
                PosterId = 1, Ingredient = "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", DietTypeId = 4,
                PostDate = DateTime.Now,
                FromPrice = 30000, ToPrice = 70000, FromCalories = 500, ToCalories = 800
            },
            new Recipe
            {
                Id = 5, Title = "Vegetable egg rolls",
                Description =
                    "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. " +
                    "Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. " +
                    "In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help " +
                    "strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs " +
                    "helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, " +
                    "limit frequent hunger, and reduce calories in the body.",
                PosterId = 1, Ingredient = "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", DietTypeId = 1,
                PostDate = DateTime.Now,
                FromPrice = 30000, ToPrice = 70000, FromCalories = 500, ToCalories = 800
            }
        );

        modelBuilder.Entity<Tutorial>().HasData(
            new Tutorial()
            {
                Id = 1, RecipeId = 1, StepTile = "Step 1 - Prepare vegetables",
                StepContent =
                    "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water " +
                    "and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot." +
                    " Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. " +
                    "Remove to a bowl of ice cold water and soak for 5 minutes, then remove " +
                    "to a plate to drain. Beat the eggs"
            },
            new Tutorial()
            {
                Id = 2, RecipeId = 1, StepTile = "Step 2 - Crack",
                StepContent =
                    "Crack 4 eggs into a clean bowl, season with 1 tablespoon of seasoning powder, beat well until the yolks and whites blend together."
            },
            new Tutorial()
            {
                Id = 3, RecipeId = 1, StepTile = "Step 3 - Frie eggs",
                StepContent =
                    "Place the pan on the stove, turn on medium heat and add 1 tablespoon of cooking oil to the pan\nWait for the oil to heat up, then add the eggs and fry for about " +
                    "3-5 minutes\nWhen the eggs are cooked, put them on a plate, use a spoon to spread the raw sausage on top of the eggs, then add the string beans and carrots, " +
                    "use your hands to roll the ingredients tightly"
            },
            new Tutorial()
            {
                Id = 4, RecipeId = 1, StepTile = "Step 4 - Put the water",
                StepContent =
                    "Put the water on the stove, place the steamer basket on the pot, put the rolled eggs in the basket and steam for 7-10 minutes. Wait for the water to boil, " +
                    "then slice the eggs into circles about 1 inch long, arrange them on a plate to enjoy"
            },
            new Tutorial()
            {
                Id = 5, RecipeId = 2, StepTile = "Step 1 - Prepare vegetables",
                StepContent =
                    "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water " +
                    "and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot." +
                    " Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. " +
                    "Remove to a bowl of ice cold water and soak for 5 minutes, then remove " +
                    "to a plate to drain. Beat the eggs"
            },
            new Tutorial()
            {
                Id = 6, RecipeId = 2, StepTile = "Step 1 - Prepare vegetables",
                StepContent =
                    "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water " +
                    "and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot." +
                    " Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. " +
                    "Remove to a bowl of ice cold water and soak for 5 minutes, then remove " +
                    "to a plate to drain. Beat the eggs"
            }, 
            new Tutorial()
            {
                Id = 7, RecipeId = 3, StepTile = "Step 1 - Prepare vegetables",
                StepContent =
                    "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water " +
                    "and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot." +
                    " Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. " +
                    "Remove to a bowl of ice cold water and soak for 5 minutes, then remove " +
                    "to a plate to drain. Beat the eggs"
            },
            new Tutorial()
            {
                Id = 8, RecipeId = 3, StepTile = "Step 1 - Prepare vegetables",
                StepContent =
                    "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water " +
                    "and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot." +
                    " Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. " +
                    "Remove to a bowl of ice cold water and soak for 5 minutes, then remove " +
                    "to a plate to drain. Beat the eggs"
            },
            new Tutorial()
            {
                Id = 9, RecipeId = 4, StepTile = "Step 1 - Prepare vegetables",
                StepContent =
                    "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water " +
                    "and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot." +
                    " Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. " +
                    "Remove to a bowl of ice cold water and soak for 5 minutes, then remove " +
                    "to a plate to drain. Beat the eggs"
            },
            new Tutorial()
            {
                Id = 10, RecipeId = 5, StepTile = "Step 1 - Prepare vegetables",
                StepContent =
                    "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water " +
                    "and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot." +
                    " Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. " +
                    "Remove to a bowl of ice cold water and soak for 5 minutes, then remove " +
                    "to a plate to drain. Beat the eggs"
            },
            new Tutorial()
            {
                Id = 11, RecipeId = 5, StepTile = "Step 2 - Prepare vegetables",
                StepContent =
                    "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water " +
                    "and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot." +
                    " Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. " +
                    "Remove to a bowl of ice cold water and soak for 5 minutes, then remove " +
                    "to a plate to drain. Beat the eggs"
            }
        );
    }
}