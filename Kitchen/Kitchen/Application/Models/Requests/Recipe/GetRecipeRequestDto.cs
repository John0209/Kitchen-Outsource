using Kitchen.Application.Models.Responses.Recipe;
using MediatR;

namespace Kitchen.Application.Models.Requests.Recipe;

public class GetRecipeRequestDto : IRequest<List<GetRecipeResponseDto>>
{
    public int RecipeCategoryId { get; set; }
    public int MealTypeId { get; set; }
}