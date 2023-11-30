using Herokume.Application.Contracts.Persistance;
using Herokume.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Herokume.Persisitance.Repositories;

public class EpisodeRepository : GenaricRepository<Episode>, IEpisodeRepository
{
    private readonly HerokumeDbContext _dbContext;

    public EpisodeRepository(HerokumeDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Episode> GetEpisodeDetails(Guid id)
    {
        var episodes = _dbContext.Episodes as IQueryable<Episode>;
        return await episodes.Include(x => x.Series)
            .ThenInclude(x => x.Comments).OrderBy(x => x.EpisodeNumber)
            .FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<List<Episode>> GetSeriesEpisodes(Guid seriesId)
    {
        var episodes = _dbContext.Episodes as IQueryable<Episode>;
        return await episodes.Where(x => x.SeriesId == seriesId).ToListAsync();

    }
}
