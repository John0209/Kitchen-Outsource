using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Recipe;
using Kitchen.Application.Models.Responses.Recipe;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Recipe;

public class QuickSortRecipeHandler : IRequestHandler<QuickSortRecipeRequest, List<GetRecipeResponse>>
{
    private readonly IUnitOfWork _unit;

    public QuickSortRecipeHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<GetRecipeResponse>> Handle(QuickSortRecipeRequest request, CancellationToken cancellationToken)
    {
        var recipes = await _unit.RecipeRepository.QuickSortAsync(request);

        if (recipes.Count == 0)
        {
            throw new BadRequestException("MealTypeId or RecipedId not found");
        }

        return RecipeMapper.RecipesToListRecipeResponseDto(recipes);
    }
}