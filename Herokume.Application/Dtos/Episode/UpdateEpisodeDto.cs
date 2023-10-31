using MediatR;

namespace Herokume.Application.Dtos.Episode;

public class UpdateEpisodeDto:IRequest
{
   public string Name { get; set; } = string.Empty;
   public string EpisodeUrl { get; set; }
}
