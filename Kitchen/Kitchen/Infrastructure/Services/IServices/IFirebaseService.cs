using Kitchen.Application.Models.Requests.Momo;

namespace Kitchen.Infrastructure.Services.IServices;

public interface IFirebaseService
{
    public Task<string?> UploadImage(IFormFile file, string? fileName);
    public Task<string?> GetImage(string? fileName);
}