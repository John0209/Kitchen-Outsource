using Kitchen.Application.Models.Requests.Recipe;
using Kitchen.Application.Models.Responses.Recipe;
using Kitchen.Infrastructure.Entities;
using Kitchen.Infrastructure.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/recipes")]
public class RecipeController : ControllerBase
{
    private IMediator _mediator;

    public RecipeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Show ra các recipes theo category và meal type
    /// </summary>
    /// <param name="category">Chọn thể loại công thức</param>
    /// <param name="meal">Chọn bữa ăn </param>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<ActionResult<GetRecipeResponseDto>> GetRecipe(Infrastructure.Enum.RecipeCategoryEnum category, MealTypeEnum meal)
    {
        var dto = new GetRecipeRequestDto
        {
            MealTypeId = (int)meal,
            RecipeCategoryId = (int)category
        };
        var result = await _mediator.Send(dto);
        return Ok(result);
    }

    /// <summary>
    /// Show thông tin chi tiết của một Recipe
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet("details")]
    public async Task<ActionResult<GetRecipeDetailResponseDto>> GetRecipeDetails(GetRecipeDetailRequestDto dto)
    {
        var result = await _mediator.Send(dto);
        return Ok(result);
    }
}