using Herokume.Application.Dtos.Category;
using Herokume.Application.Dtos.Comment;
using MediatR;

namespace Herokume.Application.Features.Commands.Comment.Request
{
    public class EditComment : IRequest
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public Guid SeriesId { get; set; }
        public Guid EpisodeId { get; set; }
        public UpdateCommentDto UpdateCommentDto { get; set; }

    }
}
