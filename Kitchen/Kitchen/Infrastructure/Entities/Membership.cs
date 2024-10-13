using System.ComponentModel.DataAnnotations.Schema;
using Kitchen.Infrastructure.Enum;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class Membership : BaseEntity
{
    [Column(TypeName = "decimal(18, 2)")] public decimal Price { get; set; }
    public ValidityPeriodType ValidityPeriod { get; set; }

    public virtual ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();
}