using Herokume.Application.Dtos.Comment;
using MediatR;

namespace Herokume.Application.Features.Commands.Comment.Request;

public class CreateCommentForSeries : IRequest<Guid>
{
    public CreateCommentForSeriesDto? CreateCommentDto { get; set; }
}
