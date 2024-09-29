using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Plan;
using Kitchen.Application.Models.Responses.Plan;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Plan;

public class GetPlanHandler : IRequestHandler<GetPlanRequest, List<GetPlanResponse>>
{
    private readonly IUnitOfWork _unit;

    public GetPlanHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<GetPlanResponse>> Handle(GetPlanRequest request, CancellationToken cancellationToken)
    {
        var plan = await _unit.PlanRepository.GetPlansByUserId(request.UserId);

        if (plan.Count == 0)
        {
            throw new BadRequestException("List plan is empty");
        }

        return PlanMapper.PlansToListGetPlanResponse(plan);
    }
}