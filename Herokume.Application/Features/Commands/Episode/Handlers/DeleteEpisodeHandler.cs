using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Episode.Requests;
using MediatR;
namespace Herokume.Application.Features.Commands.Episode.Handlers;

public class DeleteEpisodeHandler : IRequestHandler<DeleteEpisode, Unit>
{  private readonly IEpisodeRepository _episodeRepository;
    private readonly IMapper _mapper;

    public DeleteEpisodeHandler(IEpisodeRepository episodeRepository, IMapper mapper)
    {
        _episodeRepository = episodeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteEpisode request, CancellationToken cancellationToken)
    {
        var episode = await _episodeRepository.Get(request.Id);
        if (episode == null)
            throw new EpsiodeNotFoundException(nameof(episode), request.Id);
        await _episodeRepository.Delete(episode);
        return Unit.Value;
    }
}
