using Herokume.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Herokume.Persisitance.Specifications
{
    public class SpecificaitionEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, Specification<TEntity> specification)
            where TEntity : BaseEntity
        {
            var query = inputQuery;

            if (specification.Cratiria != null)
            {
                query = query.Where(specification.Cratiria);
            }

            query = specification.Includes?.Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);
            }
            if (specification.IsSplitQuery)
            {
                query = query.AsSplitQuery();
            }

            return query;
        }
    }
}
