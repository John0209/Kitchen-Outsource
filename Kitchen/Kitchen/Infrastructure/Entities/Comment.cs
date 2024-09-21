using System.ComponentModel.DataAnnotations;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class Comment : BaseEntity
{
    [MaxLength(500)] public string? Content { get; set; }
    public DateTime CommentDate { get; set; }
    // Relation

    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public int PostId { get; set; }
    public virtual Post? Post { get; set; }
}