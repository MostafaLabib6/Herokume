using Herokume.Application.Contracts.Persistance;
using Herokume.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokume.Persisitance.Repositories
{
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
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Episode>> GetSeriesEpisodes(Guid seriesId)
        {
            var episodes = _dbContext.Episodes as IQueryable<Episode>;
            return await episodes.Where(x => x.SeriesId == seriesId).ToListAsync();

        }
    }
}
