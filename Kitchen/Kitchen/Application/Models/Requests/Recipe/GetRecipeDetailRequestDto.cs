using Kitchen.Application.Models.Responses.Recipe;
using MediatR;

namespace Kitchen.Application.Models.Requests.Recipe;

public class GetRecipeDetailRequestDto : IRequest<GetRecipeDetailResponseDto>
{
    public int RecipeId { get; set; }
}