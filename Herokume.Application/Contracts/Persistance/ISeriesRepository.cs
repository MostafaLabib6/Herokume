using Herokume.Application.Features.Queries.Series;
using Herokume.Domain.Entities;

namespace Herokume.Application.Contracts.Persistance;

public interface ISeriesRepository:IGenaricRepository<Series>
{
    Task<Series> GetSeriesDetails(Guid id);//this includes comments ,Episodes and Categories
}
