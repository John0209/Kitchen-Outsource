namespace Kitchen.Application.Models.Responses.Recipe;

public class GetRecipeResponseDto
{
    public int RecipeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string MealType { get; set; } = string.Empty;
    public string RecipeCategory { get; set; } = string.Empty;
}