using Herokume.Domain.Common;
using System.Linq.Expressions;

namespace Herokume.Persisitance.Specifications
{
    public abstract class Specification<TEntity>
        where TEntity : BaseEntity
    {

        public Expression<Func<TEntity, bool>>? Cratiria { get; }

        public List<Expression<Func<TEntity, object>>>? Includes { get; } = new();
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }

        public bool IsSplitQuery { get; protected set; } = false;
        public bool IsPagingEnabled { get; private set; } = false;
        public int Take { get; private set; } = 0;
        public int Skip { get; private set; } = 0;


        public Specification(Expression<Func<TEntity, bool>> cratiria)
        {
            Cratiria = cratiria;
        }

        public void AddInclude(Expression<Func<TEntity, object>> include)
            => Includes.Add(include);

        public void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        public void ApplyOrderBy(Expression<Func<TEntity, object>> orderBy)
            => OrderBy = orderBy;

        public void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescending)
            => OrderByDescending = orderByDescending;


    }
}
