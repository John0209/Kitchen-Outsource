using Kitchen.Infrastructure.Enum;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class Membership : BaseEntity
{
    public decimal Price { get; set; }
    public ExpireType ExpireTime { get; set; }

    public virtual ICollection<User>? Users { get; set; } = new List<User>();
}