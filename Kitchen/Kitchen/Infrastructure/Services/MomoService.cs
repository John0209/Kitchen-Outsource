using System.Text;
using Application.ErrorHandlers;
using Kitchen.Application.Gateway.IConfiguration;
using Kitchen.Application.Models.Requests.Payment;
using Kitchen.Application.Models.Responses.Momo;
using Kitchen.Application.UnitOfWork;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Services.IServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Kitchen.Infrastructure.Services;

public class MomoService : IMomoService
{
    private IMomoConfig _momoConfig;
    private IUnitOfWork _unit;

    public MomoService(IMomoConfig momoConfig, IUnitOfWork unit)
    {
        _momoConfig = momoConfig;
        _unit = unit;
    }

    private string GetLinkMomoGateway(string paymentUrl, MomoPaymentRequest momoRequest)
    {
        using HttpClient client = new HttpClient();
        var requestData = JsonConvert.SerializeObject(momoRequest, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        });
        var requestContent = new StringContent(requestData, Encoding.UTF8, "application/json");

        var httpResponseMessage = client.PostAsync(paymentUrl, requestContent).Result;
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<MomoPaymentResponse>(responseContent);
            // return QRcode
            if (responseData?.resultCode == 0)
                return responseData.payUrl;
            throw new NotImplementException($"Create QR Momo failed in GetLinkMomoGateway function: {responseData?.message}");
        }

        throw new NotImplementException($"Create QR Momo failed in GetLinkMomoGateway function: {httpResponseMessage.ReasonPhrase}");
    }

    private string MakeSignatureMomoPayment(string accessKey, string secretKey, MomoPaymentRequest momo)
    {
        var rawHash = "accessKey=" + accessKey +
                      "&amount=" + momo.amount + "&extraData=" + momo.extraData +
                      "&ipnUrl=" + momo.ipnUrl + "&orderId=" + momo.orderId +
                      "&orderInfo=" + momo.orderInfo + "&partnerCode=" + momo.partnerCode +
                      "&redirectUrl=" + momo.redirectUrl + "&requestId=" + momo.requestId + "&requestType=" +
                      momo.requestType;
        return momo.signature = HashingUtils.HmacSha256(rawHash, secretKey);
    }

    public async Task<string?> CreatePaymentMomoAsync(int id)
    {
        var momoRequest = new MomoPaymentRequest();
        //Get order có parent id và order id vs status payment
        var transaction = await _unit.TransactionRepository.GetByIdAsync(id);

        // Lấy thông tin cho payment
        momoRequest.requestId = StringUtils.GenerateRandomNumberString(4) + "-" + transaction!.UserId;
        momoRequest.orderId = StringUtils.GenerateRandomNumberString(4) + "-" + transaction!.Id;
        momoRequest.amount = (long)transaction.Membership!.Price;
        momoRequest.redirectUrl = _momoConfig.ReturnUrl;
        momoRequest.ipnUrl = _momoConfig.IpnUrl;
        momoRequest.partnerCode = _momoConfig.PartnerCode;
        momoRequest.orderInfo = " 'Kitchen Buddy' - Bạn đang thanh toán cho gói member";
        momoRequest.signature = MakeSignatureMomoPayment
            (_momoConfig.AccessKey, _momoConfig.SecretKey, momoRequest);

        // lấy link QR momo
        var result = GetLinkMomoGateway(_momoConfig.PaymentUrl, momoRequest);
        return result;
    }
}