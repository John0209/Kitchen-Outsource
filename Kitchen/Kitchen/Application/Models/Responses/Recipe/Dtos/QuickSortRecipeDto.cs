namespace Kitchen.Application.Models.Responses.Recipe.Dtos;

public class QuickSortRecipeDto
{
    public string? ImageUrl { get; set; }
    public string Description { get; set; } = string.Empty;
    public int RecipeId { get; set; }
    public string Title { get; set; } = string.Empty;
}