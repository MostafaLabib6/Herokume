using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Series;
using Herokume.Application.Exceptions;
using MediatR;

namespace Herokume.Application.Features.Queries.Series.Handler;

public class GetSeriesDetailsHandler : IRequestHandler<GetSeriesDetails, SeriesDetailsDto>
{
    private readonly ISeriesRepository _seriesRepository;
    private readonly IMapper _mapper;

    public GetSeriesDetailsHandler(ISeriesRepository seriesRepository, IMapper mapper)
    {
        _seriesRepository = seriesRepository;
        _mapper = mapper;
    }

    public async Task<SeriesDetailsDto> Handle(GetSeriesDetails request, CancellationToken cancellationToken)
    {
        var Series = await _seriesRepository.GetSeriesDetails(request.Id);
        if (Series == null) 
            throw new SeriesNotFoundException(nameof(Series), request.Id);
        var SeriesDto = _mapper.Map<SeriesDetailsDto>(Series);
        return SeriesDto;
    }
}
