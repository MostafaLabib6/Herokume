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
    public class CategoryRepository : GenaricRepository<Category>, ICategoryRepository
    {
        private readonly HerokumeDbContext _dbContext;

        public CategoryRepository(HerokumeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
