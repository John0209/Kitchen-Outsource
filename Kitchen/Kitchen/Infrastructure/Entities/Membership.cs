using Kitchen.Infrastructure.Enum;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class Membership : BaseEntity
{
    public decimal Price { get; set; }
    public ValidityPeriodType ValidityPeriod { get; set; }

    public virtual ICollection<User>? Users { get; set; } = new List<User>();
    public virtual ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();
}