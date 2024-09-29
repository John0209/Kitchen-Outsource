using Kitchen.Application.Models.Responses.Recipe.Dtos;
using Kitchen.Infrastructure.Enum;

namespace Kitchen.Application.Models.Responses.Recipe;

public class GetRecipeDetailResponse
{
    public string Poster { get; set; } = string.Empty;
    public string DietType { get; set; } = string.Empty;
    public int RecipeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? PostDate { get; set; }
    public string? Ingredient { get; set; }

    //Tutorial
    public List<TutorialDto> TutorialDto { get; set; } = new List<TutorialDto>();
}