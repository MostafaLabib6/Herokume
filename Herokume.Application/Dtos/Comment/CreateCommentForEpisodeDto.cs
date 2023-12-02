using System;

namespace Herokume.Application.Dtos.Comment
{
    public class CreateCommentForEpisodeDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid UserId { get; set; } = Guid.Empty;
        public Guid? EpisodeId { get; set; } = Guid.Empty;

    }
}
