using Application.ErrorHandlers;
using Firebase.Auth;
using Firebase.Storage;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Gateway.IConfiguration;
using Kitchen.Infrastructure.Services.IServices;

namespace Kitchen.Infrastructure.Services;

public class FireBaseService : IFirebaseService
{
    private IFireBaseConfig _configuration;

    public FireBaseService(IFireBaseConfig configuration)
    {
        _configuration = configuration;
    }

    private static readonly List<string> SupportedImageFile = new()
    {
        ".jpg",
        ".jpeg",
        ".png",
        ".svg",
        ".webp",
        ".heic",
        ".heif",
        ".ico",
        ".gif"
    };

    private async Task<FirebaseAuthLink> GetAuthentication()
    {
        var auth = new FirebaseAuthProvider(new FirebaseConfig(_configuration.ApiKey));
        return await auth.SignInWithEmailAndPasswordAsync(_configuration.AuthEmail,
            _configuration.AuthPassword);
    }

    public async Task<string?> UploadImage(IFormFile file, string? fileName)
    {
        try
        {
            var stream = file.OpenReadStream();

            var fileExtension = Path.GetExtension(file.FileName);

            //Check file extension for preventing malware
            if (!SupportedImageFile.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
            {
                throw new BadRequestException("Unsupported file type.");
            }

            fileName += fileExtension;

            var firebaseAuthLink = await GetAuthentication();

            var task = new FirebaseStorage(_configuration.Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuthLink.FirebaseToken),
                        ThrowOnCancel =
                            true // when you cancel the upload, exception is thrown. By default no exception is thrown
                    })
                .Child(fileName)
                .PutAsync(stream);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            return await task;
        }
        catch (Exception e)
        {
            throw new NotImplementException("Upload file to drive is failed, Details: " + e);
        }
    }

    public async Task<string?> GetImage(string? fileName)
    {
        try
        {
            var firebaseAuthLink = await GetAuthentication();

            var task = new FirebaseStorage(_configuration.Bucket, new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuthLink.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(fileName)
                .GetDownloadUrlAsync();

            return await task;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}