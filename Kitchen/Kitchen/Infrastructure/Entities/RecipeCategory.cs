using System.ComponentModel.DataAnnotations;

namespace Kitchen.Infrastructure.Entities;

public class RecipeCategory : BaseEntity
{
    [MaxLength(40)] public string CategoryName { get; set; } = string.Empty;

    // Relation
    public virtual ICollection<Recipe>? Recipes { get; set; } = new List<Recipe>();
}