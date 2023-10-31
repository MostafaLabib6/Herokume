using Herokume.Application.Dtos.Series;
using MediatR;

namespace Herokume.Application.Features.Queries.Series;
public class GetSeriesList : IRequest<List<SeriesListDto>>
{
}
