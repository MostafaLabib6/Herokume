using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Episode;
using Herokume.Application.Features.Queries.Episodes.Requests;
using MediatR;

namespace Herokume.Application.Features.Queries.Episodes.Handlers;

public class GetEpisodesListHandler : IRequestHandler<GetEpisodesList, List<EpisodeListDto>>
{
        
    private readonly IEpisodeRepository _episodeRepository;
    private readonly IMapper _mapper;

    public GetEpisodesListHandler(IEpisodeRepository episodeRepository, IMapper mapper)
    {
        _episodeRepository = episodeRepository;
        _mapper = mapper;
    }

    public async Task<List<EpisodeListDto>> Handle(GetEpisodesList request, CancellationToken cancellationToken)
    {
        var episodes = await _episodeRepository.GetAll();
        return _mapper.Map<List<EpisodeListDto>>(episodes);
    }
}
