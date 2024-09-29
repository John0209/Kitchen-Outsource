using Kitchen.Application.Models.Responses.Plan;
using MediatR;

namespace Kitchen.Application.Models.Requests.Plan;

public class GetPlanRequest : IRequest<List<GetPlanResponse>>
{
    public int UserId { get; set; }
}