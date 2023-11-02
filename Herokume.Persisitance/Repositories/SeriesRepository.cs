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
