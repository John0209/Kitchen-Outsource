using System.ComponentModel.DataAnnotations;
using Kitchen.Infrastructure.Entities;

namespace RecipeCategoryEnum.Entities;

public class Tutorial : BaseEntity
{
    [MaxLength(100)] public string StepTile  { get; set; } = string.Empty;
    [MaxLength(1000)] public string StepContent   { get; set; } = string.Empty;

    //Relation
    public int RecipeId { get; set; }
    public virtual Recipe? Recipe { get; set; }
}