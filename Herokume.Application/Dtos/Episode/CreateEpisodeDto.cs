using Herokume.Application.Dtos.Series;

namespace Herokume.Application.Dtos.Episode;

public class CreateEpisodeDto
{
    public string Name { get; set; } = string.Empty;
    public string? EpisodeURL { get; set; }
    public SeriesDetailsDto Series { get; set; }
}
