namespace Kitchen.Infrastructure.Services.IServices;

public interface IMomoService
{
    public Task<string?> CreatePaymentMomoAsync(int id);
}