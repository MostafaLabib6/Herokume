using Herokume.Application.Dtos.Comment;
using Herokume.Application.Dtos.Episode;
using Herokume.Domain.Entities;

namespace Herokume.Application.Dtos.Series;

public class SeriesDetailsDto:BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public string? Trailer { get; set; }
    public float Rating { get; set; }
    public string? Image { get; set; }
    public int Likes { get; set; }
    public int Views { get; set; } //point to the number of views.
    public bool AddToWatchList { get; set; } = false;
    public List<SeriesDetailsDto>? RelatedTo { get; set; }
    public List<CommentsListDto>? Comments { get; set; }
    public List<EpisodeListDto>? Episodes { get; set; }
    //public List<CategoryDto>? categories { get; set; }
}
