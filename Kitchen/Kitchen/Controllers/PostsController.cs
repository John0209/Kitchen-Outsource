using Kitchen.Application.Models.Requests.Forum;
using Kitchen.Infrastructure.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/posts")]
public class PostsController : ControllerBase
{
    private IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Thêm mới 1 bài post
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreatePosts(CreatePostsRequest dto)
    {
        await _mediator.Send(dto);
        return Ok(new
        {
            Message = "Create Posts Successful"
        });
    }

    /// <summary>
    /// Show những posts theo category 
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> GetPosts(PostCategoryEnum category)
    {
        var dto = new GetPostsRequest() { CategoryId = (int)category };
        var result = await _mediator.Send(dto);
        return Ok(result);
    }

    /// <summary>
    /// Vào xem chi tiết của một Post
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet("detail")]
    public async Task<IActionResult> GetPostDetail(GetPostDetailRequest dto)
    {
        var result = await _mediator.Send(dto);
        return Ok(result);
    }
    /// <summary>
    /// User thêm comment vào 1 bài post
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPatch("comment")]
    public async Task<IActionResult> UpdateComment(UserCommentRequest dto)
    {
        await _mediator.Send(dto);
        return Ok(new
        {
            Message = "Update new comment successful"
        });
    }
}