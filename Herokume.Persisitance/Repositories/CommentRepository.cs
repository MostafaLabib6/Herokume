using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Comment;
using Herokume.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Herokume.Persisitance.Repositories;

public class CommentRepository : GenaricRepository<Comment>, ICommentRepository
{
    private readonly HerokumeDbContext _dbContext;

    public CommentRepository(HerokumeDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<BaseComment> CreateComment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public async Task<List<Comment>> GetCommentsWithReplies() =>
        await _dbContext.Comments.Include(x => x.Responses).ToListAsync();

}
