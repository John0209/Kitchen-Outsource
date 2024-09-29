using Kitchen.Infrastructure.Enum;

namespace Kitchen.Application.Models.Requests.Plan;

public class PlanDto
{
    public DayEnum Day { get; set; }
    public string Content { get; set; } = String.Empty;
}