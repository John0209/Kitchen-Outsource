using Kitchen.Application.Models.Responses.Authenticate;
using Kitchen.Application.Models.Responses.Estimate;
using Kitchen.Application.Models.Responses.Recipe;
using Kitchen.Application.Models.Responses.Recipe.Dtos;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Mapper;

public static class RecipeMapper
{
    public static List<QuickSortRecipeResponse> RecipeToListQuickSortRecipeResponse(IEnumerable<IGrouping<string, Recipe>> groupedData)
    {
        List<QuickSortRecipeResponse> recipeResponses = new List<QuickSortRecipeResponse>();
        foreach (var group in groupedData)
        {
            List<QuickSortRecipeDto> recipeInfo = new List<QuickSortRecipeDto>();
            foreach (var recipe in group)
            {
                QuickSortRecipeDto recipeDto = new QuickSortRecipeDto()
                {
                    RecipeId = recipe.Id,
                    Description = recipe.Description,
                    ImageUrl = recipe.ImageUrl,
                    Title = recipe.Title,
                };
                recipeInfo.Add(recipeDto);
            }

            QuickSortRecipeResponse quickSortRecipeDto = new QuickSortRecipeResponse()
            {
                RecipeInfo = recipeInfo,
                DietType = group.Key
            };
            recipeResponses.Add(quickSortRecipeDto);
        }

        return recipeResponses;
    }

    public static List<GetRecipeResponse> RecipesToListRecipeResponseDto(List<Recipe> dtos)
    {
        return dtos.Select(x => new GetRecipeResponse()
        {
            RecipeId = x.Id,
            ImageUrl = x.ImageUrl,
            Description = x.Description,
            DietType = x.DietType!.DietName,
            Title = x.Title
        }).ToList();
    }

    public static EstimateCostResponse RecipeToEstimateResponse(Recipe dto) => new EstimateCostResponse()
    {
        FromPrice = dto.FromPrice,
        ToPrice = dto.ToPrice,
        FromCalories = dto.FromCalories,
        ToCalories = dto.ToCalories,
        DietType = dto.DietType!.DietName,
        RecipeId = dto.Id,
        Title = dto.Title,
        Description = dto.Description,
        ImageUrl = dto.ImageUrl
    };

    public static GetRecipeDetailResponse RecipeToRecipeDetailResponseDto(Recipe dto) => new GetRecipeDetailResponse()
    {
        Poster = dto.Poster!.Name,
        DietType = dto.DietType!.DietName,
        RecipeId = dto.Id,
        Title = dto.Title,
        Description = dto.Description,
        ImageUrl = dto.ImageUrl,
        PostDate = DateUtils.FormatDateTimeToDatetimeV1(dto.PostDate),
        Ingredient = dto.Ingredient,
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