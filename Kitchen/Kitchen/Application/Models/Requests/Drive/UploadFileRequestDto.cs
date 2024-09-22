using Kitchen.Infrastructure.Enum;
using MediatR;

namespace Kitchen.Application.Models.Requests.Drive;

public class UploadFileRequestDto : IRequest<Unit>
{
    public int Id { get; set; }
    public required IFormFile File { get; set; }
    public UploadType UploadType { get; set; }
    public ContentType ContentType { get; set; }
}