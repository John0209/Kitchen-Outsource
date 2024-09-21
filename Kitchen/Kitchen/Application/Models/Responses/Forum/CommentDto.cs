namespace Kitchen.Application.Models.Responses.Forum;

public class CommentDto
{
    public string? Avarta { get; set; }
    public string Commenter { get; set; } = string.Empty;
    public string? CommentContent { get; set; }
    public string? CommentDate { get; set; }
}