using System.ComponentModel.DataAnnotations;
using Actor.Infrastructure.Enum;
using Kitchen.Infrastructure.Entities;

namespace RecipeCategoryEnum.Entities;

public class Post : BaseEntity
{
    [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [MaxLength(1000)] public string Content { get; set; } = string.Empty;
    [MaxLength(300)]public string? ImageUrl { get; set; } = string.Empty;
    public DateTime PostDate { get; set; }
    public PostStatus Status { get; set; }

    // Relation

    public int PosterId { get; set; }
    public virtual User? Poster { get; set; }

    public int PostCategoryId  { get; set; }
    public virtual PostCategory? PostCategory { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
}