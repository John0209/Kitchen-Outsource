using Kitchen.Application.Models.Responses.Estimate;
using MediatR;

namespace Kitchen.Application.Models.Requests.Estimate;

public class EstimateCostRequest : IRequest<EstimateCostResponse>
{
    public int RecipeId { get; set; }
}