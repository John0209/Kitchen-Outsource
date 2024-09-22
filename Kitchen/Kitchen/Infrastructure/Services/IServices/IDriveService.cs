using Kitchen.Infrastructure.Enum;

namespace Kitchen.Infrastructure.Services.IServices;

public interface IDriveService
{
    public Task<string?> UploadFileToGoogleDrive(IFormFile fileVideo, string? fileName, ContentType type);
}