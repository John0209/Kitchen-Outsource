using System.ComponentModel.DataAnnotations;
using Kitchen.Infrastructure.Entities;

namespace RecipeCategoryEnum.Entities;

public class Ingredient : BaseEntity
{
    [MaxLength(300)] public string? Content { get; set; }
    public int NumberOfPeople  { get; set; }

    // Relation
    public virtual Recipe? Recipe { get; set; }
}