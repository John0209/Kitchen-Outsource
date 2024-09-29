using System.ComponentModel.DataAnnotations;
using Kitchen.Infrastructure.Enum;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class Plan : BaseEntity
{
    public DayEnum Day { get; set; }
    [MaxLength(500)] public string Content { get; set; } = string.Empty;
    
    // Relation
    public int? UserId { get; set; }
    public virtual User? User { get; set; }
}