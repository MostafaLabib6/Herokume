using Herokume.Application.Dtos.Comment;
using Herokume.Domain.Entities;

namespace Herokume.Application.Contracts.Persistance;

public interface ICommentRepository:IGenaricRepository<Comment>
{
    public Task<List<Comment>> GetCommentsWithReplies();
    //public Task<BaseComment> CreateComment();
}
