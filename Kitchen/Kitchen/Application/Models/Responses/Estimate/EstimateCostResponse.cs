namespace Kitchen.Application.Models.Responses.Estimate;

public class EstimateCostResponse
{
    public string DietType { get; set; } = string.Empty;
    public int RecipeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal FromPrice { get; set; }
    public decimal ToPrice { get; set; }
    public int FromCalories { get; set; }
    public int ToCalories { get; set; }
}