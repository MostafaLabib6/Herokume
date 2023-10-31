namespace Herokume.Application.Dtos.Episode;

public class EpisodeListDto:BaseDto
{
    public string Name { get; set; } = string.Empty;
    public int Length { get; set; }
    public string? EpisodeURL { get; set; }
}
