using Kitchen.Application.Models.Responses.Plan;
using Kitchen.Infrastructure.Entities;

namespace Kitchen.Application.Mapper;

public static class PlanMapper
{
    public static List<GetPlanResponse> PlansToListGetPlanResponse(List<Plan> dto)
    {
        return dto.Select(x => new GetPlanResponse()
        {
            Day = x.Day,
            Content = x.Content
        }).ToList();
    }
}