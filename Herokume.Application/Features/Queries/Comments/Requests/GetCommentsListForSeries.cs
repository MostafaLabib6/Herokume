using Herokume.Application.Dtos.Comment;
using MediatR;

namespace Herokume.Application.Features.Queries.Comments.Requests;

public class GetCommentsListForSeries : IRequest<List<CommentsListDto>>
{
    public Guid SeriesId
    {
        get; set;
    }
}
