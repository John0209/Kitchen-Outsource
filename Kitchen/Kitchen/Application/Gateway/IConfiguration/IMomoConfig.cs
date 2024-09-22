﻿namespace Kitchen.Application.Gateway.IConfiguration;


public interface IMomoConfig
{
    public string PartnerCode { get; } 
    public string ReturnUrl { get; }
    public string IpnUrl { get; }
    public string AccessKey { get; }
    public string SecretKey { get; }
    public string PaymentUrl { get; }
    public string RefundUrl { get; }
}
