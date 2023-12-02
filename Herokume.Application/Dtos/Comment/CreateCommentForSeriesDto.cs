using System;

namespace Herokume.Application.Dtos.Comment
{
    public class CreateCommentForSeriesDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid UserId { get; set; } = Guid.Empty;
        public Guid? SeriesId { get; set; } = Guid.Empty;

    }
}
