using Kitchen.Infrastructure.Enum;

namespace Kitchen.Application.Models.Responses.Recipe;

public class GetRecipeDetailResponseDto
{
    public string Poster { get; set; } = string.Empty;
    public string RecipeCategory { get; set; } = string.Empty;
    public int RecipeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string MealType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public string? PostDate { get; set; }

    //Ingredient
    public string? IngredientContent { get; set; }
    public int NumberOfPeople { get; set; }

    //Tutorial
    public List<TutorialDto> TutorialDto { get; set; } = new List<TutorialDto>();
}