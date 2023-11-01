using Herokume.Domain.Common;

namespace Herokume.Domain.Entities;
public class Series : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NormalizeName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public bool ShowInSlides { get; set; }
    public string? Trailer { get; set; }
    public float Rating { get; set; }
    public string? Image { get; set; }
    public int Likes { get; set; }
    public int Views { get; set; } //point to the number of views.
    public bool AddToWatchList { get; set; } = false;
    public int SeasonNumber { get; set; } = 1;
    public List<Series>? RelatedTo { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Episode>? Episodes { get; set; }
    public List<Tag>? Tags { get; set; }
    public List<Category>? categories { get; set; }
}
