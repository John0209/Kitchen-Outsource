using Application.Dtos.Request.Order.Momo;

namespace Kitchen.Infrastructure.Services.IServices;

public interface IMomoService
{
    (string?, string?) GetLinkMomoGateway(string paymentUrl, MomoPaymentRequestDto momoRequestDto);
    string MakeSignatureMomoPayment(string accessKey, string secretKey, MomoPaymentRequestDto momo);
}