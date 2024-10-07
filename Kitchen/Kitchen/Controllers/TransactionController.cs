using DataAccess.Enum;
using Kitchen.Application.Models.Requests.Momo;
using Kitchen.Application.Models.Requests.Transaction;
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

    public TransactionController(IMediator mediator, IMomoService momo)
    {
        _mediator = mediator;
        _momo = momo;
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
        var id = await _mediator.Send(dto);
        switch (type)
        {
            case PaymentType.Cash:
                return Ok(new
                {
                    TransactionId = id
                });
            case PaymentType.Momo:
                return await CreateQrMomo(id);
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
        return Ok(new
        {
            Message = "Payment successful"
        });
    }
    
}