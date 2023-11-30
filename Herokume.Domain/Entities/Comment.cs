using Herokume.Domain.Common;
namespace Herokume.Domain.Entities;
public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;
    public Series? Series { get; set; } = new Series();
    public Episode? Episode { get; set; } = new Episode();
    public Guid UserId { get; set; } = Guid.NewGuid();
    public Comment? ResponseTo { get; set; } = new();
    public ICollection<Comment>? Responses { get; set; } = new List<Comment>(); //replaies to comment.
    public int Likes { get; set; } = 0;
    public bool IsSeries { get; set; }
}
