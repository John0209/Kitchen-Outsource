namespace Kitchen.Application.Models.Responses.Recipe;

public class GetRecipeResponse
{
    public int RecipeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string DietType { get; set; } = string.Empty;
}