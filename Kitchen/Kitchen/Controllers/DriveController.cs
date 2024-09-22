using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Drive;
using Kitchen.Infrastructure.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/drives")]
public class DriveController : ControllerBase
{
    private IMediator _mediator;

    public DriveController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPatch("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file, ContentType contentType, UploadType uploadType, int id)
    {
        if (file == null) throw new BadRequestException("File is empty");

        var dto = new UploadFileRequestDto()
        {
            File = file,
            ContentType = contentType,
            UploadType = uploadType,
            Id = id
        };

        await _mediator.Send(dto);

        return Ok(new
        {
            Message = "Upload file successful"
        });
    }
}