using Herokume.Application.Dtos.Comment;
using Herokume.Application.Dtos.Series;
using Herokume.Domain.Entities;

namespace Herokume.Application.Dtos.Episode;

public class EpisodeDetailsDto:BaseDto
{
    public string Name { get; set; } = string.Empty;
    public int Length { get; set; }
    public string? EpisodeURL { get; set; }
    public int Likes { get; set; }
    public int EpisodeNumber { get; set; }
    public float Rating { get; set; }
    public BaseSeriesDto Series { get; set; }
    List<CommentsListDto>? Comments { get; set; }

}
