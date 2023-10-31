using Herokume.Application.Dtos.Series;

namespace Herokume.Application.Dtos.Category;

public class CategoryDto:BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<SeriesListDto>? Series { get; set; }
}
