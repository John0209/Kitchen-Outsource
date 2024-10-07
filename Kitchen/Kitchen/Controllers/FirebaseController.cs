using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Firebase;
using Kitchen.Infrastructure.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/firebase")]
public class FirebaseController : ControllerBase
{
    private IMediator _mediator;

    public FirebaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Upload image cho post, recipe và user avarta
    /// </summary>
    /// <param name="file"></param>
    /// <param name="uploadType"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="BadRequestException"></exception>
    [HttpPatch("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file, UploadType uploadType, int id)
    {
        if (file == null) throw new BadRequestException("File is empty");

        var dto = new UploadFileRequest()
        {
            File = file,
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