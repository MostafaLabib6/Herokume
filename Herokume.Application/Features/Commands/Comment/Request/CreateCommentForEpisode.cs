using Herokume.Application.Dtos.Comment;
using MediatR;

namespace Herokume.Application.Features.Commands.Comment.Request;

public class CreateCommentForEpisode : IRequest<Guid>
{

    public CreateCommentForEpisodeDto? CreateCommentDto { get; set; }
}
