namespace Herokume.Domain.Entities;

public class Comment
{
    public string Content { get; set; } =string.Empty;
    public Series Series { get; set; }
    public float Rating { get; set; }
    //TODO: adding user .

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Comment? ResponseTo { get; set; }
    public List<Comment>? Responses { get; set; } //replaies to comment.
    public int Likes { get; set; }
}
