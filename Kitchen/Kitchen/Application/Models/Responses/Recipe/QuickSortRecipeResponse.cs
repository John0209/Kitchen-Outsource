using Kitchen.Application.Models.Responses.Recipe.Dtos;

namespace Kitchen.Application.Models.Responses.Recipe;

public class QuickSortRecipeResponse
{
    public string DietType { get; set; } = string.Empty;
    public List<QuickSortRecipeDto> RecipeInfo { get; set; } = new List<QuickSortRecipeDto>();
}
