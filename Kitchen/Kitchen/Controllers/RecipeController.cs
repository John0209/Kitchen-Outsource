using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Recipe;
using Kitchen.Application.Models.Responses.Recipe;
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
    /// Show ra các recipes theo diet đã chọn, truyền DietId vào
    /// </summary>
    /// <param name="diet">Chọn thể loại Diet</param>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<ActionResult<GetRecipeResponse>> GetRecipe(Infrastructure.Enum.DietType diet)
    {
        var dto = new GetRecipeRequest
        {
            DietTypeId = (int)diet
        };
        var result = await _mediator.Send(dto);
        return Ok(result);
    }

    /// <summary>
    /// Show thông tin chi tiết của một Recipe, truyền recipe Id vào
    /// </summary>
    /// <returns></returns>
    [HttpGet("details/{id}")]
    public async Task<ActionResult<GetRecipeDetailResponse>> GetRecipeDetails(int id)
    {
        var dto = new GetRecipeDetailRequest() { RecipeId = id };
        var result = await _mediator.Send(dto);
        return Ok(result);
    }

    /// <summary>
    /// Chức năng quick-sort, truyền Diet Id và list Recipe Id để get thông tin
    /// </summary>
    /// <param name="dto">DietType: Daily = 1, Vegetarian = 2, Dietary = 3, Exercise = 4
    /// </param>
    /// <returns></returns>
    [HttpPost("quick-sort")]
    public async Task<ActionResult<List<GetRecipeResponse>>> QuickSort(QuickSortRecipeRequest dto)
    {
        if (dto.RecipeId!.Count == 0)
        {
            throw new BadRequestException("List is empty");
        }

        var result = await _mediator.Send(dto);
        return Ok(result);
    }
}