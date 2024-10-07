using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Excel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/excel")]
public class ExcelController : ControllerBase
{
    private IMediator _mediator;

    public ExcelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Import recipes data từ file excel, gửi file vào 
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    /// <exception cref="BadRequestException"></exception>
    [HttpPost("import")]
    public async Task<IActionResult> Import(IFormFile file)
    {
        if (file.Length == 0)
        {
            throw new BadRequestException("File is empty");
        }

        var dto = new ImportExcelRequest() { File = file };
        await _mediator.Send(dto);

        return Ok(new
        {
            Message = "Import information to recipe db successful"
        });
    }
}