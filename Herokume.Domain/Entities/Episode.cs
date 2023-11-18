using Herokume.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Herokume.Domain.Entities;

public class Episode : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Length { get; set; } = 25;
    public string? EpisodeURL { get; set; } = string.Empty;
    public int Likes { get; set; } = int.MinValue;
    public int EpisodeNumber { get; set; } = 0;
    public float Rating { get; set; } = 5;
    [ForeignKey(nameof(SeriesId))]
    public Series Series { get; set; } = new();
    public Guid SeriesId { get; set; } = Guid.NewGuid();
    public ICollection<Comment>? Comments { get; set; } = new List<Comment>();

}
