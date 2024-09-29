using Kitchen.Application.Models.Requests.Plan;
using Kitchen.Application.Models.Responses.Plan;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/plans")]
public class PlanController : ControllerBase
{
    private IMediator _mediator;

    public PlanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Thêm mới 1 plan của 1 user
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task<IActionResult> AddPlan(AddPlanRequest dto)
    {
        await _mediator.Send(dto);
        return Ok(new
        {
            Message = "Add plan to db successful"
        });
    }

    /// <summary>
    /// Lấy thông tin plan của 1 user
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetPlanResponse>> GetPlan(int id)
    {
        GetPlanRequest dto = new GetPlanRequest() { UserId = id };
        var result = await _mediator.Send(dto);
        return Ok(result);
    }
}