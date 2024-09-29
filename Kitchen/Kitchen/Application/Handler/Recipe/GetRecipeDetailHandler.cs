using Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Recipe;
using Kitchen.Application.Models.Responses.Recipe;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Recipe;

public class GetRecipeDetailHandler : IRequestHandler<GetRecipeDetailRequest, GetRecipeDetailResponse>
{
    private readonly IUnitOfWork _unit;

    public GetRecipeDetailHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<GetRecipeDetailResponse> Handle(GetRecipeDetailRequest detailRequest, CancellationToken cancellationToken)
    {
        var recipe = await _unit.RecipeRepository.GetByIdAsync(detailRequest.RecipeId) ?? throw new NotFoundException("Recipe is not found");

        return RecipeMapper.RecipeToRecipeDetailResponseDto(recipe);
    }
}