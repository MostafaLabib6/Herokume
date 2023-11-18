using Herokume.Application.Dtos.Series;

namespace Herokume.Application.Dtos.Episode;

public class CreateEpisodeDto
{
    public string Name { get; set; } = string.Empty;
    public string? EpisodeURL { get; set; }
    public int EpisodeNumber { get; set; } = 0;
    public int Length { get; set; } = 25;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    //public BaseSeriesDto Series { get; set; } can set it ez. Cause it's created before episodes.
}
