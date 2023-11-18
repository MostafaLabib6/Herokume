using Herokume.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Herokume.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;
    public Series? Series { get; set; } = new Series();
    public Episode? Episode { get; set; } = new Episode();
    public float Rating { get; set; } = float.MinValue;
    //TODO: adding user .    
    public Comment? ResponseTo { get; set; } = new();
    public ICollection<CommentResponse> Responses { get; set; } = new List<CommentResponse>(); //replaies to comment.
    public int Likes { get; set; } = int.MinValue;
}

public class CommentResponse : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public Guid CommentId { get; set; } = Guid.NewGuid();
    public Comment Comment { get; set; } = new Comment();
}