using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Episode.Validators;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Episode.Requests;
using MediatR;

namespace Herokume.Application.Features.Commands.Episode.Handlers;

public class UpdateEpisodeHandler : IRequestHandler<UpdateEpisode, Unit>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public UpdateEpisodeHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateEpisode request, CancellationToken cancellationToken)
    {
        var series = await _unitofWork.SeriesRepository.Get(request.SeriesId);
        if (series == null)
            throw new SeriesNotFoundException(nameof(series), request.SeriesId);

        var validator = new UpdateEpisodeDtoValidator();
        var validatorResult = await validator.ValidateAsync(request.UpdateEpisodeDto, cancellationToken);
        if (!validatorResult.IsValid)
            throw new Exception();

        var epsiode = _unitofWork.EpisodeRepository.Get(request.Id);
        if (epsiode == null)
            throw new EpsiodeNotFoundException(nameof(epsiode), request.Id);

        var UpdatedEpisode = _mapper.Map<Domain.Entities.Episode>(request.UpdateEpisodeDto);
        await _unitofWork.EpisodeRepository.Update(UpdatedEpisode);

        return Unit.Value;
    }
}
