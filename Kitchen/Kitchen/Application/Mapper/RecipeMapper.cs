using Kitchen.Application.Models.Responses.Authenticate;
using Kitchen.Application.Models.Responses.Recipe;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Mapper;

public static class RecipeMapper
{
    public static List<GetRecipeResponseDto> RecipesToListRecipeResponseDto(List<Recipe> dtos)
    {
        return dtos.Select(x => new GetRecipeResponseDto()
        {
            RecipeId = x.Id,
            ImageUrl = x.ImageUrl,
            Description = x.Description,
            MealType = x.MealType!.TypeName,
            Title = x.Title,
            RecipeCategory = x.RecipeCategory!.CategoryName
        }).ToList();
    }

    public static GetRecipeDetailResponseDto RecipeToRecipeDetailResponseDto(Recipe dto) => new GetRecipeDetailResponseDto()
    {
        Poster = dto.Poster!.Name,
        RecipeCategory = dto.RecipeCategory!.CategoryName,
        RecipeId = dto.Id,
        Title = dto.Title,
        MealType = dto.MealType!.TypeName,
        Description = dto.Description,
        ImageUrl = dto.ImageUrl,
        VideoUrl = dto.VideoUrl,
        PostDate = DateUtils.FormatDateTimeToDatetimeV1(dto.PostDate),
        IngredientContent = dto.Ingredient!.Content,
        NumberOfPeople = dto.Ingredient!.NumberOfPeople,
        TutorialDto = ConvertToTutorialDtos(dto.Tutorials!.ToList())
    };

    private static List<TutorialDto> ConvertToTutorialDtos(List<Tutorial> dto)
    {
        return dto.Select(x => new TutorialDto()
        {
            StepContent = x.StepContent,
            StepTile = x.StepTile
        }).ToList();
    }
}