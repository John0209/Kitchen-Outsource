using System.ComponentModel.DataAnnotations;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class DietType : BaseEntity
{
    [MaxLength(40)] public string DietName { get; set; } = string.Empty;

    // Relation
    public virtual ICollection<Recipe>? Recipes { get; set; } = new List<Recipe>();
}