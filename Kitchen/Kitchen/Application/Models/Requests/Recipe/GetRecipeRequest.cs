using Kitchen.Application.Models.Responses.Recipe;
using MediatR;

namespace Kitchen.Application.Models.Requests.Recipe;

public class GetRecipeRequest : IRequest<List<GetRecipeResponse>>
{
    public int DietTypeId { get; set; }
}