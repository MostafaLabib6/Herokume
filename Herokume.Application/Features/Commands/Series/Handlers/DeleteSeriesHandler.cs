using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Series.Requests;
using MediatR;

namespace Herokume.Application.Features.Commands.Series.Handlers;

public class DeleteSeriesHandler : IRequestHandler<DeleteSeries, Unit>
{
    private readonly ISeriesRepository _seriesRepository;
    private readonly IMapper _mapper;

    public DeleteSeriesHandler(ISeriesRepository seriesRepository, IMapper mapper)
    {
        _seriesRepository = seriesRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteSeries request, CancellationToken cancellationToken)
    {
        var series = await _seriesRepository.Get(request.Id);
        if (series == null)
            throw new SeriesNotFoundException(nameof(series), request.Id);
        _seriesRepository.Delete(series);
        return Unit.Value;
    }
}
