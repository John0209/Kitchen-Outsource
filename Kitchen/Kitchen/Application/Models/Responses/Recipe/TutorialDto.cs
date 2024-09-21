using System.ComponentModel.DataAnnotations;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Models.Responses.Recipe;

public class TutorialDto
{
    public string StepTile { get; set; } = string.Empty;
    public string StepContent { get; set; } = string.Empty;
}