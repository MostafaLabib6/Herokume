using Herokume.Application.Contracts.Persistance;
using Herokume.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Herokume.Persisitance.Repositories;

public class SeriesRepository : GenaricRepository<Series>, ISeriesRepository
{
    private readonly HerokumeDbContext _dbContext;

    public SeriesRepository(HerokumeDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetNumberofEpisodesinSeries(Guid seriesId)
    {
        var series = await _dbContext.Series
              .Include(s => s.Episodes)
              .FirstOrDefaultAsync(s => s.ID == seriesId);

        var count = series?.Episodes?.Count() ?? 0;
        return count;
    }

    public async Task<List<Series>> GetRandomSeries(int count = 10)
    {
        var ids = await GetRandomSeriesIds(count);
        return await _dbContext.Series.Where(x => ids.Contains(x.ID)).ToListAsync();
    }

    private async Task<List<Guid>> GetRandomSeriesIds(int count = 1)
    {
        var random = new Random();
        var allseriesIds = await _dbContext.Series.Select(x => x.ID).ToListAsync();

        count = Math.Min(count, allseriesIds.Count());
        var randomSeriesIds = allseriesIds.OrderBy(x => random.Next()).Take(count).ToList();

        return randomSeriesIds;
    }

    public async Task<Series> GetSeriesDetails(Guid id)
    {
        return await _dbContext.Series
            .Include(x => x.Episodes)
            .Include(x => x.categories)
            .Include(x => x.Tags)
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.ID == id) ?? default!;
    }
}
