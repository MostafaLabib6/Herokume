using Herokume.Application.Dtos.Comment;
using MediatR;

namespace Herokume.Application.Features.Commands.Comment.Request;

public class CreateComment : IRequest
{
    public Guid UserId { get; set; }
    public Guid SeriesId { get; set; }
    public Guid EpisodeId { get; set; }
    public CreateCommentDto? CreateCommentDto { get; set; }
}
