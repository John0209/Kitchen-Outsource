using System.ComponentModel.DataAnnotations;
using Actor.Infrastructure.Enum;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class User : BaseEntity
{
    [MaxLength(50)] public string UserName { get; set; } = string.Empty;
    [MaxLength(20)] public string PhoneNumber { get; set; } = string.Empty;
    [MaxLength(50)] public string Email { get; set; } = string.Empty;
    [MaxLength(300)] public string? Avarta { get; set; } = string.Empty;
    [MaxLength(50)] public string? Address { get; set; } = string.Empty;
    [MaxLength(50)] public string Password { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public DateTime CreateDate { get; set; }
    public GenderType? Gender { get; set; }
    public UserStatus Status { get; set; }
    public int? VerifyCode { get; set; }

    // Relation
    public int? MembershipId { get; set; }
    public virtual Membership? Membership { get; set; }

    public virtual ICollection<Post>? Posts { get; set; } = new List<Post>();
    public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
}