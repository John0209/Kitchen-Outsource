using Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Excel;
using Kitchen.Application.UnitOfWork;
using Kitchen.Infrastructure.Enum;
using Kitchen.Infrastructure.Services.IServices;
using MediatR;
using OfficeOpenXml;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Handler.Excel;

public class ImportExcelHandler : IRequestHandler<ImportExcelRequest, Unit>
{
    private readonly IUnitOfWork _unit;
    private IFirebaseService _firebase;

    public ImportExcelHandler(IUnitOfWork unit, IFirebaseService firebase)
    {
        _unit = unit;
        _firebase = firebase;
    }

    public async Task<Unit> Handle(ImportExcelRequest request, CancellationToken cancellationToken)
    {
        // Đảm bảo rằng EPPlus có thể sử dụng
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var stream = new MemoryStream())
        {
            await request.File.CopyToAsync(stream, cancellationToken);
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Lấy worksheet đầu tiên
                var rowCount = worksheet.Dimension.Rows; // Số lượng hàng

                // Khởi tạo list recipes để add vào database
                int number = 1;
                var recipes = new List<Infrastructure.Entities.Recipe>();
                for (int row = 2; row <= rowCount; row++)
                {
                    var recipeDto = new Infrastructure.Entities.Recipe()
                    {
                        PosterId = 1,
                        PostDate = DateTime.Now,
                        ImageUrl = await GetImageFromFirebase(number, UploadType.Recipe)
                    };

                    for (int col = 1; col <= 10; col++)
                    {
                        var cellTitle = worksheet.Cells[6, col].Text.Trim(); // Lấy giá trị title
                        var cellValue = worksheet.Cells[row, col].Text.Trim(); // Lấy giá trị ô

                        ExcelToRecipeDto(cellTitle, cellValue, ref recipeDto);
                    }

                    number++;
                    recipes.Add(recipeDto);
                }

                await _unit.RecipeRepository.AddRangeAsync(recipes);
                if (await _unit.SaveChangeAsync() < 0)
                    throw new NotImplementException("Add list recipes to DB failed");
            }
        }

        return Unit.Value;
    }

    private void ExcelToRecipeDto(string title, string value, ref Infrastructure.Entities.Recipe recipe)
    {
        Enum.TryParse<ExcelTitle>(title, out var excelTitle);

        switch (excelTitle)
        {
            case ExcelTitle.Title:
                recipe.Title = value;
                break;
            case ExcelTitle.Description:
                recipe.Description = value;
                break;
            case ExcelTitle.FromPrice:
                recipe.FromPrice = decimal.Parse(value);
                break;
            case ExcelTitle.ToPrice:
                recipe.ToPrice = decimal.Parse(value);
                break;
            case ExcelTitle.DietId:
                recipe.DietTypeId = Int16.Parse(value);
                break;
            case ExcelTitle.Ingredient:
                recipe.Ingredient = value;
                break;
            case ExcelTitle.FromCalories:
                recipe.FromCalories = Int16.Parse(value);
                break;
            case ExcelTitle.ToCalories:
                recipe.ToCalories = Int16.Parse(value);
                break;
            case ExcelTitle.Tutorials:
                var tutorialSplit = value.Split('\n');
                ExcelToTutorialDto(tutorialSplit, ref recipe);
                break;
        }
    }

    private void ExcelToTutorialDto(string[] tutorialSplit, ref Infrastructure.Entities.Recipe recipe)
    {
        var tutorials = new List<Tutorial>();
        int count = 1;
        foreach (var dto in tutorialSplit)
        {
            var tutorialDto = new Tutorial()
            {
                Recipe = recipe,
                StepTile = "Bước - " + count,
                StepContent = dto
            };
            tutorials.Add(tutorialDto);
            count++;
        }

        recipe.Tutorials = tutorials;
    }

    private async Task<string?> GetImageFromFirebase(int id, UploadType type)
    {
        string fileName = type + "-" + id + ".jpg";
        return await _firebase.GetImage(fileName);
    }
}