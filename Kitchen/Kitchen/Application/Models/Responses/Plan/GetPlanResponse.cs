using Kitchen.Infrastructure.Enum;

namespace Kitchen.Application.Models.Responses.Plan;

public class GetPlanResponse
{
    public DayEnum Day { get; set; }
    public string Content { get; set; } = String.Empty;
}