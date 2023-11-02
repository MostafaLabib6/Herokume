using Herokume.Domain.Common;

namespace Herokume.Domain.Entities;

public class Comment:BaseEntity
{
    public string Content { get; set; } =string.Empty;
    public Series Series { get; set; }
    public float Rating { get; set; }
    //TODO: adding user .
    public Comment? ResponseTo { get; set; }
    public ICollection<Comment>? Responses { get; set; } //replaies to comment.
    public int Likes { get; set; }
}
