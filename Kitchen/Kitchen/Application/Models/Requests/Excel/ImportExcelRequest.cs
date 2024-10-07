using MediatR;

namespace Kitchen.Application.Models.Requests.Excel;

public class ImportExcelRequest : IRequest<Unit>
{
    public required IFormFile File { get; set; }
}