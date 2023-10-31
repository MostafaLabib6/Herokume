using Herokume.Domain.Entities;

namespace Herokume.Application.Contracts.Persistance;

public interface IEpisodeRepository : IGenaricRepository<Episode>
{
    Task<Episode> GetEpisodeDetails(int id); //contains Series and comments
}
