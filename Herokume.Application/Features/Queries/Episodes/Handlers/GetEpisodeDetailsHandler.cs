using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Episode;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Queries.Episodes.Requests;
using MediatR;

namespace Herokume.Application.Features.Queries.Episodes.Handlers;

public class GetEpisodeDetailsHandler : IRequestHandler<GetEpisodeDetails, EpisodeDetailsDto>
{

    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public GetEpisodeDetailsHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }

    public async Task<EpisodeDetailsDto> Handle(GetEpisodeDetails request, CancellationToken cancellationToken)
    {
        var series = await _unitofWork.SeriesRepository.Get(request.Id);
        if (series == null)
            throw new SeriesNotFoundException(nameof(series), request.SeriesId);

        var episode = await _unitofWork.EpisodeRepository.Get(request.Id);
        if (episode == null)
            throw new EpsiodeNotFoundException(nameof(episode), request.Id);

        return _mapper.Map<EpisodeDetailsDto>(episode);
    }
}
