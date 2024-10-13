using DataAccess.Enum;
using Kitchen.Application.Handler.Transaction;
using Kitchen.Application.Models.Requests.Payment;
using Kitchen.Application.Models.Requests.Transaction;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Services.IServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/transactions")]
public class TransactionController : ControllerBase
{
    private IMediator _mediator;
    private IMomoService _momo;
    private CakeTransactionHandler _handler;

    public TransactionController(IMediator mediator, IMomoService momo, CakeTransactionHandler handler)
    {
        _mediator = mediator;
        _momo = momo;
        _handler = handler;
    }

    /// <summary>
    /// Tạo mới 1 transaction
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task<IActionResult> AddTransaction(CreateTransactionRequest dto, PaymentType type)
    {
        if (type == 0)
        {
            return BadRequest("Vui lòng chọn payment type");
        }

        var transaction = await _mediator.Send(dto);
        switch (type)
        {
            case PaymentType.Momo:
                return await CreateQrMomo(transaction.Id);
            case PaymentType.Cake:
                EmailUtils.IsReadMail = true;
                return Ok(new
                {
                    Content = "Member-" + transaction.TransactionCode
                });
        }

        return Ok();
    }

    /// <summary>
    /// Tạo QR thanh toán cho Momo, truyền transaction id vào
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("momo/{id}")]
    public async Task<IActionResult> CreateQrMomo(int id)
    {
        var result = await _momo.CreatePaymentMomoAsync(id);
        return Ok(new
        {
            QR = result
        });
    }

    /// <summary>
    /// Api cho momo service call sau khi thanh toán thành công
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("momo-return")]
    public async Task<IActionResult> MomoReturnAsync([FromQuery] MomoResultRequest dto)
    {
        await _mediator.Send(dto);
        return Redirect("https://kitchen-buddy-two.vercel.app/pages/homepage.html");
    }

    /// <summary>
    /// Thanh toán thủ công nếu payement auto không hoạt động
    /// </summary>
    /// <returns></returns>
    [HttpGet("cake")]
    public async Task<IActionResult> Cake()
    {
        EmailUtils.IsReadMail = true;
        await _handler.CheckCakeEmail();
        return Ok(new
        {
            Message = "Payment By Cake Successful"
        });
        //var result =await EmailUtils.ReadEmailAsyncTest();
        //return Ok(result);
    }
}