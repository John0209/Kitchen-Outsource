using Actor.Infrastructure.Enum;
using Kitchen.Application.Models.Requests.User;
using Kitchen.Application.Models.Responses.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Show thông tin chi tiết của user
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("details")]
    public async Task<ActionResult<GetUserDetailResponseDto>> UpdateProfile(int userId)
    {
        var dto = new GetUserDetailRequestDto() { UserId = userId };
        var result = await _mediator.Send(dto);
        return Ok(result);
    }

    /// <summary>
    /// Update thông tin user profile
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateProfile(UpdateProfileRequestDto dto)
    {
        await _mediator.Send(dto);
        return Ok(new
        {
            Message = "Update user profile successful"
        });
    }
}