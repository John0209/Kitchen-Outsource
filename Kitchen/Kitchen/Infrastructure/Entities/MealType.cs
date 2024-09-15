using System.ComponentModel.DataAnnotations;

namespace Kitchen.Infrastructure.Entities;

public class MealType : BaseEntity
{
    [MaxLength(40)] public string TypeName { get; set; } = string.Empty;

    // Relation
    public virtual ICollection<Recipe>? Recipes { get; set; } = new List<Recipe>();
}