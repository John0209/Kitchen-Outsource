using System.ComponentModel.DataAnnotations;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class Recipe : BaseEntity
{
    [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [MaxLength(1000)] public string Description { get; set; } = string.Empty;
    [MaxLength(300)] public string? ImageUrl { get; set; } = string.Empty;
    [MaxLength(300)] public string? VideoUrl { get; set; } = string.Empty;
    public DateTime PostDate { get; set; }
    // Relation

    public int PosterId { get; set; }
    public virtual Admin? Poster { get; set; }

    public int IngredientId { get; set; }
    public virtual Ingredient? Ingredient { get; set; }

    public int MealTypeId { get; set; }
    public virtual MealType? MealType { get; set; }

    public int RecipeCategoryId { get; set; }
    public virtual RecipeCategory? RecipeCategory { get; set; }

    public virtual ICollection<Tutorial>? Tutorials { get; set; } = new List<Tutorial>();
}