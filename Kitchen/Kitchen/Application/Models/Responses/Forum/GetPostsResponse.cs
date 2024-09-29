namespace Kitchen.Application.Models.Responses.Forum;

public class GetPostsResponse
{
    public int PostId { get; set; }
    public string? ImageUrl { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int? NumberOfComment { get; set; }
}