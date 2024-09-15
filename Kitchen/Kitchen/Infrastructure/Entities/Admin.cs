using System.ComponentModel.DataAnnotations;

namespace Kitchen.Infrastructure.Entities;

public class Admin : BaseEntity
{
    [MaxLength(50)] public string Name { get; set; } = string.Empty;
    [MaxLength(50)] public string Account { get; set; } = string.Empty;
    [MaxLength(50)] public string Password { get; set; } = string.Empty;
    
    //Relation
    public virtual ICollection<Recipe>? Recipes { get; set; } = new List<Recipe>();
}