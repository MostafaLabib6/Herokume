namespace Herokume.Application.Dtos.Comment;

public class CommentsListDto:BaseDto
{
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<BaseComment>? Responses { get; set; } //replaies to comment.
}
