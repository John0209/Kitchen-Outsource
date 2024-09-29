using System.ComponentModel.DataAnnotations;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class Transaction : BaseEntity
{
    public DateTime TransactionDate { get; set; }
    [MaxLength(8)] public string TransactionCode { get; set; } = string.Empty;

    // Relation
    public int? UserId { get; set; }
    public virtual User? User { get; set; }

    public int? MembershipId { get; set; }
    public virtual Membership? Membership { get; set; }
}