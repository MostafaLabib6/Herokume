using Herokume.Domain.Entities;

namespace Herokume.Application.Contracts.Persistance;

public interface ICommentRepository:IGenaricRepository<Comment>
{
    public Task<List<Comment>> GetCommentsWithReplies();
}
