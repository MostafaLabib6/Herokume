using Herokume.Application.Dtos.Comment;
using MediatR;

namespace Herokume.Application.Features.Queries.Comments.Requests;

public class GetCommentsListForEpisode : IRequest<List<CommentsListDto>>
{
    public Guid EpisodeId { get; set; }
}
