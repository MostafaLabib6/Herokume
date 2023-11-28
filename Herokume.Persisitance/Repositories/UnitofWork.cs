using Herokume.Application.Contracts.Persistance;
using Herokume.Infrastrcture;
using Microsoft.AspNetCore.Http;

namespace Herokume.Persisitance.Repositories;

public class UnitofWork : IUnitofWork
{
    private readonly HerokumeDbContext _context;
    private ISeriesRepository _seriesRepository;
    private ICategoryRepository _categoryRepository;
    private IEpisodeRepository _episodeRepository;
    private ICommentRepository _commentRepository;
    private ITagRepository _tagRepository;

    public UnitofWork(HerokumeDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context ?? throw new ArgumentNullException();
    }

    public ISeriesRepository SeriesRepository =>
        _seriesRepository ??= new SeriesRepository(_context);
    public ICommentRepository CommentRepository =>
        _commentRepository ??= new CommentRepository(_context);
    public ICategoryRepository CategoryRepository =>
        _categoryRepository = new CategoryRepository(_context);
    public IEpisodeRepository EpisodeRepository =>
        _episodeRepository ??= new EpisodeRepository(_context);
    public ITagRepository TagRepository =>
        _tagRepository;

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }

}
