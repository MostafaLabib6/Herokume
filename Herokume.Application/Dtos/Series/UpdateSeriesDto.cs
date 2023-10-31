using Herokume.Application.Dtos.Category;
using Herokume.Application.Dtos.Episode;

namespace Herokume.Application.Dtos.Series;

public class UpdateSeriesDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Image { get; set; }
    public List<CategoryListDto>? categories { get; set; }
}
