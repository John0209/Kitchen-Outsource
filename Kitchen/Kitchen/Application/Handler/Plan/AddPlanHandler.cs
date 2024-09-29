using Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Plan;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Plan;

public class AddPlanHandler : IRequestHandler<AddPlanRequest, Unit>
{
    private readonly IUnitOfWork _unit;

    public AddPlanHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<Unit> Handle(AddPlanRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unit.UserRepository.GetByIdAsync(request.UserId) ??
                       throw new NotFoundException("UserId not found");

            var planEntity = request.Plans.Select(x => new Infrastructure.Entities.Plan()
            {
                Day = x.Day,
                Content = x.Content,
                UserId = request.UserId
            }).ToList();

            if (user.Plans?.Count > 0)
            {
                _unit.PlanRepository.RemoveRange(user.Plans!);
            }

            await _unit.PlanRepository.AddRangeAsync(planEntity);

            if (await _unit.SaveChangeAsync() < 0) throw new NotImplementException("Update user profile to DB failed");
            return Unit.Value;
        }
        catch (Exception e)
        {
            throw new NotImplementException(e.Message);
        }
    }
}