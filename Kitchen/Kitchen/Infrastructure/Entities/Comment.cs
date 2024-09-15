using System.ComponentModel.DataAnnotations;

namespace Kitchen.Infrastructure.Entities;

public class Comment : BaseEntity
{
    [MaxLength(50)] public string? Content { get; set; }
    public DateTime CommentDate { get; set; }
    // Relation

    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public int PostId { get; set; }
    public virtual Post? Post { get; set; }
}