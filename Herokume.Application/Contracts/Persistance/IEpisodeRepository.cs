using Herokume.Domain.Entities;

namespace Herokume.Application.Contracts.Persistance;

public interface IEpisodeRepository : IGenaricRepository<Episode>
{
    Task<Episode> GetEpisodeDetails(Guid id); //contains Series and comments
    Task<List<Episode>> GetSeriesEpisodes(Guid sereisId);
}
