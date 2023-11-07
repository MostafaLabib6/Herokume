using Herokume.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Herokume.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;
    public Series? Series { get; set; }
    public Episode? Episode { get; set; }
    public float Rating { get; set; }
    //TODO: adding user .
    public Comment? ResponseTo { get; set; } = new();
    public ICollection<CommentResponse> Responses { get; set; } = new List<CommentResponse>(); //replaies to comment.
    public int Likes { get; set; }
}

public class CommentResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public Guid CommentId { get; set; }
    public Comment Comment
    {
        get; set;
    }
}