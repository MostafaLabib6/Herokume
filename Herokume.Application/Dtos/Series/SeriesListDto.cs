namespace Herokume.Application.Dtos.Series;

public class SeriesListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public string? Trailer { get; set; }
    public int SeasonNumber { get; set; }
    public string Description { get; set; } = string.Empty;
}
