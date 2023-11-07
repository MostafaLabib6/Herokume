using Herokume.Domain.Common;

namespace Herokume.Domain.Entities;
public class Series : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NormalizeName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool ShowInSlides { get; set; }
    public string? Trailer { get; set; }
    public float Rating { get; set; }
    public string? Image { get; set; }
    public int Likes { get; set; }
    public int Views { get; set; } //point to the number of views.
    public bool AddToWatchList { get; set; } = false;
    public int SeasonNumber { get; set; } = 1;
    public ICollection<RelatedSeries>? RelatedTo { get; set; } = new List<RelatedSeries>();
    public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
    public ICollection<Episode>? Episodes { get; set; } = new List<Episode>();
    public ICollection<Tag>? Tags { get; set; } = new List<Tag>();
    public ICollection<Category>? categories { get; set; } = new List<Category>();
}
public class RelatedSeries
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public float Rating { get; set; }
}