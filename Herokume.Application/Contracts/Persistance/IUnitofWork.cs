using System.Reflection.Metadata.Ecma335;

namespace Herokume.Application.Contracts.Persistance;

public interface IUnitofWork : IDisposable
{
    public ISeriesRepository SeriesRepository { get; }
    public ICommentRepository CommentRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IEpisodeRepository EpisodeRepository { get; }
    public ITagRepository TagRepository { get; }
    //TODO: adding user repsoitory
}
