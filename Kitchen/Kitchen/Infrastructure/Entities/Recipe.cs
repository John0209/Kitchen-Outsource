using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class Recipe : BaseEntity
{
    [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [MaxLength(1000)] public string Description { get; set; } = string.Empty;
    [MaxLength(300)] public string? ImageUrl { get; set; } = string.Empty;
    [MaxLength(300)] public string? Ingredient { get; set; } = string.Empty;
    public DateTime PostDate { get; set; }
    [Column(TypeName = "decimal(18, 2)")] public decimal FromPrice { get; set; }
    [Column(TypeName = "decimal(18, 2)")] public decimal ToPrice { get; set; }
    public int FromCalories { get; set; }
    public int ToCalories { get; set; }

    // Relation
    public int PosterId { get; set; }
    public virtual Admin? Poster { get; set; }

    public int DietTypeId { get; set; }
    public virtual DietType? DietType { get; set; }

    public virtual ICollection<Tutorial>? Tutorials { get; set; } = new List<Tutorial>();
}