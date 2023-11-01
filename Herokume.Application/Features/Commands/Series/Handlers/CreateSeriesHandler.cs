using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Episode.Validators;
using Herokume.Application.Dtos.Series;
using Herokume.Application.Dtos.Series.Validator;
using Herokume.Application.Features.Commands.Series.Requests;
using MediatR;

namespace Herokume.Application.Features.Commands.Series.Handlers;

public class CreateSeriesHandler : IRequestHandler<CreateSeries, Unit>
{
    private readonly ISeriesRepository _seriesRepository;
    private readonly IMapper _mapper;

    public CreateSeriesHandler(ISeriesRepository seriesRepository, IMapper mapper)
    {
        _seriesRepository = seriesRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateSeries request, CancellationToken cancellationToken)
    {
        var validator = new BaseSeriesDtoValidator();
        var validatorResult = await validator.ValidateAsync(request.CreateSeriesDto, cancellationToken);
        if (!validatorResult.IsValid)
            throw new Exception();

        var series = _mapper.Map<Domain.Entities.Series>(request.CreateSeriesDto);
        _seriesRepository.Add(series);
        bool valid = await _seriesRepository.Save();
        //if (valid) 
        return Unit.Value;
    }
}
