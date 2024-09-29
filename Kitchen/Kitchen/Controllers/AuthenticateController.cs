using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Application.Models.Responses.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/authenticate")]
public class AuthenticateController : ControllerBase
{
    private IMediator _mediator;

    public AuthenticateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Login dành cho User
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("user/login")]
    public async Task<ActionResult<UserLoginResponse>> Login(UserLoginRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// <summary>
    /// Login dành cho admin
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("admin/login")]
    public async Task<ActionResult<string>> AdminLogin(AdminLoginRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(new
        {
            Message = "Login Successful",
            AdminName = result
        });
    }

    /// <summary>
    /// Login dành cho expert
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("expert/login")]
    public async Task<ActionResult<string>> ExpertLogin(ExpertLoginRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(new
        {
            Message = "Login Successful",
            ExpertName = result
        });
    }

    /// <summary>
    /// Đăng ký tài khoản mới cho user
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// <summary>
    /// Nhập code đã được gửi trong email để xác thực tài khoản
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("verify")]
    public async Task<IActionResult> Verify(VerifyRequest request)
    {
        await _mediator.Send(request);

        return Ok(new
        {
            Message = "Verification successful"
        });
    }

    /// <summary>
    /// Nhập email vào để khôi phục lại password
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("recover")]
    public async Task<IActionResult> Recover(RecoverRequest request)
    {
        await _mediator.Send(request);

        return Ok(new
        {
            Message = "New password has been sent to email " + request.Email
        });
    }

    /// <summary>
    /// Thay đổi user password
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPatch("change-pass")]
    public async Task<IActionResult> ChangePass(PassChangeRequest request)
    {
        await _mediator.Send(request);

        return Ok(new
        {
            Message = "Change password successful"
        });
    }
}