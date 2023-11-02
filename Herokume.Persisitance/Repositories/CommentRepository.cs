using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Comment;
using Herokume.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokume.Persisitance.Repositories
{
    public class CommentRepository : GenaricRepository<Comment>, ICommentRepository
    {
        private readonly HerokumeDbContext _dbContext;

        public CommentRepository(HerokumeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<BaseComment> CreateComment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<List<Comment>> GetCommentsWithReplies() =>
            await _dbContext.Comments.Include(x=>x.Responses).ToListAsync();

        //Task<BaseComment> ICommentRepository.CreateComment()
        //{
        //    //TODO:
        //}
    }
}
