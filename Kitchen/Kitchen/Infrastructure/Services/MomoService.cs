using System.Text;
using Application.Dtos.Request.Order.Momo;
using Application.Dtos.Response.Order.Momo;
using Application.ErrorHandlers;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Services.IServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Kitchen.Infrastructure.Services;

public class MomoService : IMomoService
{
    public (string?, string?) GetLinkMomoGateway(string paymentUrl, MomoPaymentRequestDto momoRequestDto)
    {
        using HttpClient client = new HttpClient();
        var requestData = JsonConvert.SerializeObject(momoRequestDto, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        });
        var requestContent = new StringContent(requestData, Encoding.UTF8, "application/json");

        var createPaymentLink = client.PostAsync(paymentUrl, requestContent).Result;
        if (createPaymentLink.IsSuccessStatusCode)
        {
            var responseContent = createPaymentLink.Content.ReadAsStringAsync().Result;
            var responeseData = JsonConvert.DeserializeObject<MomoPaymentResponseDto>(responseContent);
            // return QRcode
            if (responeseData?.resultCode == 0)
                return (responeseData.payUrl, responeseData.qrCodeUrl);
            throw new NotImplementException($"Error Momo: {responeseData?.message}");
        }

        throw new NotImplementException($"Error Momo: {createPaymentLink.ReasonPhrase}");
    }

    public string MakeSignatureMomoPayment(string accessKey, string secretKey, MomoPaymentRequestDto momo)
    {
        var rawHash = "accessKey=" + accessKey +
                      "&amount=" + momo.amount + "&extraData=" + momo.extraData +
                      "&ipnUrl=" + momo.ipnUrl + "&orderId=" + momo.orderId +
                      "&orderInfo=" + momo.orderInfo + "&partnerCode=" + momo.partnerCode +
                      "&redirectUrl=" + momo.redirectUrl + "&requestId=" + momo.requestId + "&requestType=" +
                      momo.requestType;
        return momo.signature = HashingUtils.HmacSha256(rawHash, secretKey);
    }
}