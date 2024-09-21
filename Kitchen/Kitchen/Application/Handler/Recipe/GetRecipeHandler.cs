using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Recipe;
using Kitchen.Application.Models.Responses.Recipe;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Recipe;

public class GetRecipeHandler : IRequestHandler<GetRecipeRequestDto, List<GetRecipeResponseDto>>
{
    private readonly IUnitOfWork _unit;

    public GetRecipeHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<GetRecipeResponseDto>> Handle(GetRecipeRequestDto request, CancellationToken cancellationToken)
    {
        var recipes = await _unit.RecipeRepository.GetRecipesAsync(request);

        if (recipes.Count < 1)
            throw new BadRequestException("List recipe is empty, Mr.John please consider the problem");

        return RecipeMapper.RecipesToListRecipeResponseDto(recipes);
    }
}