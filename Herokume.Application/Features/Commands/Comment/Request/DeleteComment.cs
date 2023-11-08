using MediatR;
namespace Herokume.Application.Features.Commands.Comment.Request;

public class DeleteComment : IRequest
{
    public Guid CommentId { get; set; } = Guid.Empty;
    public Guid UserId { get; set; } = Guid.Empty;
    public Guid SeriesId { get; set; } = Guid.Empty;
    public Guid EpisodeId { get; set; } = Guid.Empty;
}
