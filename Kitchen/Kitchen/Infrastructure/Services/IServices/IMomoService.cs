using Application.Dtos.Request.Order.Momo;
using Kitchen.Application.Models.Requests.Momo;

namespace Kitchen.Infrastructure.Services.IServices;

public interface IMomoService
{
    (string?, string?) GetLinkMomoGateway(string paymentUrl, MomoPaymentRequest momoRequest);
    string MakeSignatureMomoPayment(string accessKey, string secretKey, MomoPaymentRequest momo);
}