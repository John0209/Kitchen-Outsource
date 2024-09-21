namespace Kitchen.Application.Models.Responses.Forum;

public class GetPostDetailResponseDto
{
    public int PostId { get; set; }
    public string? Avarta { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? PostDate { get; set; }
    public string? PostImageUrl { get; set; }
    public string PostContent { get; set; } = string.Empty;
    public int? NumberOfComment { get; set; }
    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
}