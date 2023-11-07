using Herokume.Application.Contracts.Persistance;

namespace Herokume.Persisitance.Repositories;

public class UnitofWork : IUnitofWork
{
    public ISeriesRepository SeriesRepository { get; set; }
    public ICommentRepository CommentRepository { get; set; }
    public ICategoryRepository CategoryRepository { get; set; }
    public IEpisodeRepository EpisodeRepository { get; set; }
    public ITagRepository TagRepository { get; set; }
}
