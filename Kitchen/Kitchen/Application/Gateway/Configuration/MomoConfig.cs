using Kitchen.Application.Gateway.IConfiguration;

namespace Kitchen.Application.Gateway.Configuration
{
    public class MomoConfig : IMomoConfig
    {
        private readonly IConfigurationSection _section;

        public static string ConfigName => "Momo";
        public string PartnerCode => _section[nameof(PartnerCode)];
        public string ReturnUrl => _section[nameof(ReturnUrl)];
        public string IpnUrl => _section[nameof(IpnUrl)];
        public string AccessKey => _section[nameof(AccessKey)];
        public string SecretKey => _section[nameof(SecretKey)];
        public string PaymentUrl => _section[nameof(PaymentUrl)];
        public string RefundUrl => _section[nameof(RefundUrl)];

        public MomoConfig(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _section = configuration.GetSection(ConfigName);
        }
    }
}
