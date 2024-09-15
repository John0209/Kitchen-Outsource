using System.ComponentModel.DataAnnotations;
using Kitchen.Infrastructure.Enum;

namespace Kitchen.Infrastructure.Entities;

public class Post : BaseEntity
{
    [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [MaxLength(100)] public string Content { get; set; } = string.Empty;
    [MaxLength(300)]public string? ImageUrl { get; set; } = string.Empty;
    public DateTime PostDate { get; set; }
    public PostStatus Status { get; set; }

    // Relation

    public int PosterId { get; set; }
    public virtual User? User { get; set; }

    public int PostCategoryId  { get; set; }
    public virtual PostCategory? PostCategory { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
}