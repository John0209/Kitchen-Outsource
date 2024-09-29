using Kitchen.Application.Models.Responses.Recipe;
using MediatR;

namespace Kitchen.Application.Models.Requests.Recipe;

public class GetRecipeDetailRequest : IRequest<GetRecipeDetailResponse>
{
    public int RecipeId { get; set; }
}