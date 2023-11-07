using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Category.Validators;
using Herokume.Application.Dtos.Episode.Validators;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Episode.Requests;
using MediatR;

namespace Herokume.Application.Features.Commands.Episode.Handlers;

public class CreateEpisodeHandler : IRequestHandler<CreateEpisode, Guid>
{
    //private readonly IEpisodeRepository _episodeRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public CreateEpisodeHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateEpisode request, CancellationToken cancellationToken)
    {
        var series = await _unitofWork.SeriesRepository.Get(request.SeriesId);
        if (series == null)
            throw new SeriesNotFoundException(nameof(series), request.SeriesId);

        var validator = new CreateEpisodeDtoValidator(_unitofWork);
        var validatorResult = await validator.ValidateAsync(request.CreateEpisodeDto, cancellationToken);
        if (!validatorResult.IsValid)
            throw new Exception();

        var Episode = _mapper.Map<Domain.Entities.Episode>(request.CreateEpisodeDto);
        var entity = await _unitofWork.EpisodeRepository.Add(Episode);

        return entity.ID;
    }
}
