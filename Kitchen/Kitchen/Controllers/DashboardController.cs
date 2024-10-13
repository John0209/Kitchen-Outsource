using Kitchen.Application.Models.Requests.Dashboard;
using Kitchen.Application.Models.Responses.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/dashboards")]
public class DashboardController : ControllerBase
{
    private IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetDashboardResponse>>> GetDashboard()
    {
        var dto = new EmptyRequest();
        var result = await _mediator.Send(dto);

        return Ok(result);
    }
    
}