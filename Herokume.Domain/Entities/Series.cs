using Herokume.Domain.Common;

namespace Herokume.Domain.Entities;
public class Series : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NormalizeName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool ShowInSlides { get; set; } = false;
    public string? Trailer { get; set; } = string.Empty;
    public float Rating { get; set; } = float.MinValue;
    public string? Image { get; set; } = string.Empty;
    public int Likes { get; set; } = int.MinValue;
    public int Views { get; set; } = int.MinValue; //point to the number of views.
    public bool AddToWatchList { get; set; } = false;
    public int SeasonNumber { get; set; } = 1;
    public ICollection<RelatedSeries>? RelatedTo { get; set; } = new List<RelatedSeries>();
    public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
    public ICollection<Episode>? Episodes { get; set; } = new List<Episode>();
    public ICollection<Tag>? Tags { get; set; } = new List<Tag>();
    public ICollection<Category>? categories { get; set; } = new List<Category>();
}
public class RelatedSeries : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public float Rating { get; set; } = float.MinValue;
}