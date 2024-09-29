using Kitchen.Application.Models.Responses.Recipe;
using MediatR;

namespace Kitchen.Application.Models.Requests.Recipe;

public class QuickSortRecipeRequest : IRequest<List<GetRecipeResponse>>
{
    public int DietTypeId { get; set; }
    public List<int>? RecipeId { get; set; }
}