using Kitchen.Infrastructure.Enum;
using MediatR;

namespace Kitchen.Application.Models.Requests.Plan;

public class AddPlanRequest : IRequest<Unit>
{
    public int UserId { get; set; }
    public List<PlanDto> Plans { get; set; } = new List<PlanDto>();
}