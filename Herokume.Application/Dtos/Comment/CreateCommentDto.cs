using System;

namespace Herokume.Application.Dtos.Comment
{
    public class CreateCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid UserId { get; set; } = Guid.Empty;
        public Guid SeriesId { get; set; } = Guid.Empty;
        public Guid EpisodeId { get; set; } = Guid.Empty;

    }
}
