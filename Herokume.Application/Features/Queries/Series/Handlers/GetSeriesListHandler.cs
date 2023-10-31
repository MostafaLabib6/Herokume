using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Series;
using MediatR;

namespace Herokume.Application.Features.Queries.Series.Handlers;

public class GetSeriesListHandler : IRequestHandler<GetSeriesList, List<SeriesListDto>>
{

    private readonly ISeriesRepository _seriesRepository;
    private readonly IMapper _mapper;

    public GetSeriesListHandler(ISeriesRepository seriesRepository, IMapper mapper)
    {
        _seriesRepository = seriesRepository;
        _mapper = mapper;
    }

    public async Task<List<SeriesListDto>> Handle(GetSeriesList request, CancellationToken cancellationToken)
    {
        var series = await _seriesRepository.GetAll();
        return _mapper.Map<List<SeriesListDto>>(series);
    }
}
