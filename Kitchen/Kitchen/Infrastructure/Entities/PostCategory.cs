using System.ComponentModel.DataAnnotations;

namespace RecipeCategoryEnum.Entities;

public class PostCategory : BaseEntity
{
    [MaxLength(40)] public string CategoryName { get; set; } = string.Empty;

    // Relation
    public virtual ICollection<Post>? Posts { get; set; } = new List<Post>();
}