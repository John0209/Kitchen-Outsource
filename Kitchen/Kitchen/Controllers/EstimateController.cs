using Kitchen.Application.Models.Requests.Estimate;
using Kitchen.Application.Models.Responses.Estimate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/estimate")]
public class EstimateController : ControllerBase
{
    private IMediator _mediator;

    public EstimateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Estimate cost per meal
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<EstimateCostResponse>> Estimate(int id)
    {
        var dto = new EstimateCostRequest() { RecipeId = id };
        var result = await _mediator.Send(dto);
        return Ok(result);
    }
}