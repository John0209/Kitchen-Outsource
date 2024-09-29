using System.ComponentModel.DataAnnotations;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Infrastructure.Entities;

public class Expert : BaseEntity
{
    [MaxLength(50)] public string Name { get; set; } = string.Empty;
    [MaxLength(50)] public string Email { get; set; } = string.Empty;
    [MaxLength(50)] public string Password { get; set; } = string.Empty;
}