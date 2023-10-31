using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Series.Requests;
using MediatR;

namespace Herokume.Application.Features.Commands.Series.Handlers;

public class UpdateSeriesHandler : IRequestHandler<UpdateSeries, Unit>
{
     private readonly ISeriesRepository _seriesRepository;
    private readonly IMapper _mapper;

    public UpdateSeriesHandler(ISeriesRepository seriesRepository, IMapper mapper)
    {
        _seriesRepository = seriesRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSeries request, CancellationToken cancellationToken)
    {
        var series = _seriesRepository.Get(request.Id);
        if (series == null) 
            throw new SeriesNotFoundException(nameof(series),request.Id);
        var UpdatedSeries = _mapper.Map<Domain.Entities.Series>(request.UpdateSeriesDto);
        _seriesRepository.Update(UpdatedSeries);
        await _seriesRepository.Save();
        return Unit.Value;
    }
}
