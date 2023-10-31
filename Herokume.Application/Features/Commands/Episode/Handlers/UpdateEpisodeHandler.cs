using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Episode.Requests;
using MediatR;

namespace Herokume.Application.Features.Commands.Episode.Handlers;

public class UpdateEpisodeHandler : IRequestHandler<UpdateEpisode, Unit>
{
      private readonly IEpisodeRepository _episodeRepository;
    private readonly IMapper _mapper;

    public UpdateEpisodeHandler(IEpisodeRepository episodeRepository, IMapper mapper)
    {
        _episodeRepository = episodeRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateEpisode request, CancellationToken cancellationToken)
    {
        var epsiode = _episodeRepository.Get(request.Id);
        if (epsiode == null) 
            throw new SeriesNotFoundException(nameof(epsiode),request.Id);
        var UpdatedEpisode = _mapper.Map<Domain.Entities.Episode>(request.UpdateEpisodeDto);
        _episodeRepository.Update(UpdatedEpisode);
        await _episodeRepository.Save();
        return Unit.Value;
    }
}
