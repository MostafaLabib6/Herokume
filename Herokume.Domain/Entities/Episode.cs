using System.Reflection.Metadata.Ecma335;

namespace Herokume.Domain.Entities;

public class Episode
{
    public string Name { get; set; } = string.Empty;
    public int Length { get; set; }
    public string? EpisodeURL { get; set; }
    public int Likes { get; set; }
    public int EpisodeNumber { get; set; }
    public float Rating { get; set; }
    public Series Series { get; set; }
    List<Comment>? Comments { get; set; }

}
