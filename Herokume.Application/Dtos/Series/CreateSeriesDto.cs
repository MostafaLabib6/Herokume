using Herokume.Application.Dtos.Category;
using Herokume.Application.Dtos.Comment;
using Herokume.Application.Dtos.Episode;
using Microsoft.AspNetCore.Http;

namespace Herokume.Application.Dtos.Series;

public class CreateSeriesDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public string? Trailer { get; set; }
    public IFormFile ImageFile { get; set; }
    public List<EpisodeListDto>? Episodes { get; set; }
    public List<CategoryListDto>? categories { get; set; }
}
