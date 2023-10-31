using System.Reflection.Metadata.Ecma335;

namespace Herokume.Application.Contracts.Persistance;

public interface IUnitofWork
{
    public ISeriesRepository SeriesRepository { get; set; }
    public ICommentRepository CommentRepository{ get; set; }
    public ICategoryRepository CategoryRepository { get; set; }
    public IEpisodeRepository EpisodeRepository { get; set; }
    public ITagRepository TagRepository { get; set; }
    //TODO: adding user repsoitory
}
