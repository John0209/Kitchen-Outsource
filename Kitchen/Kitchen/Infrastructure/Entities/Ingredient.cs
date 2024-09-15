using System.ComponentModel.DataAnnotations;

namespace Kitchen.Infrastructure.Entities;

public class Ingredient : BaseEntity
{
    [MaxLength(50)] public string? Content { get; set; }
    public int NumberOfPeople  { get; set; }

    // Relation
    public virtual Recipe? Recipe { get; set; }
}