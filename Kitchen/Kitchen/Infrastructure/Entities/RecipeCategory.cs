using System.ComponentModel.DataAnnotations;
using Kitchen.Infrastructure.Entities;

namespace RecipeCategoryEnum.Entities;

public class RecipeCategory : BaseEntity
{
    [MaxLength(40)] public string CategoryName { get; set; } = string.Empty;

    // Relation
    public virtual ICollection<Recipe>? Recipes { get; set; } = new List<Recipe>();
}