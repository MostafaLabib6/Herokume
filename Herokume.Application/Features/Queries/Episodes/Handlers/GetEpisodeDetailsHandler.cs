using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Episode;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Queries.Episodes.Requests;
using MediatR;

namespace Herokume.Application.Features.Queries.Episodes.Handlers;

public class GetEpisodeDetailsHandler : IRequestHandler<GetEpisodeDetails, EpisodeDetailsDto>
{
    
    private readonly IEpisodeRepository _episodeRepository;
    private readonly IMapper _mapper;

    public GetEpisodeDetailsHandler(IEpisodeRepository episodeRepository, IMapper mapper)
    {
        _episodeRepository = episodeRepository;
        _mapper = mapper;
    }

    public async Task<EpisodeDetailsDto> Handle(GetEpisodeDetails request, CancellationToken cancellationToken)
    {
        var episode = await _episodeRepository.Get(request.Id);
        if (episode == null)
            throw new EpsiodeNotFoundException(nameof(episode),request.Id);
        return _mapper.Map<EpisodeDetailsDto>(episode);
    }
}
