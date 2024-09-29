using Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Estimate;
using Kitchen.Application.Models.Responses.Estimate;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Estimate;

public class EstimateCostHandler : IRequestHandler<EstimateCostRequest, EstimateCostResponse>
{
    private readonly IUnitOfWork _unit;

    public EstimateCostHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<EstimateCostResponse> Handle(EstimateCostRequest costRequest, CancellationToken cancellationToken)
    {
        var recipe = await _unit.RecipeRepository.GetByIdAsync(costRequest.RecipeId) ??
                     throw new NotFoundException("RecipeId not found");

        return RecipeMapper.RecipeToEstimateResponse(recipe);
    }
}