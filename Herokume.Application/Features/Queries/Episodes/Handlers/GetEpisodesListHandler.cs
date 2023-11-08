using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Episode;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Queries.Episodes.Requests;
using MediatR;

namespace Herokume.Application.Features.Queries.Episodes.Handlers;

public class GetEpisodesListHandler : IRequestHandler<GetEpisodesList, List<EpisodeListDto>>
{

    private readonly IUnitofWork _unitofwork;
    private readonly IMapper _mapper;

    public GetEpisodesListHandler(IUnitofWork unitofwork, IMapper mapper)
    {
        _unitofwork = unitofwork;
        _mapper = mapper;
    }

    public async Task<List<EpisodeListDto>> Handle(GetEpisodesList request, CancellationToken cancellationToken)
    {
        var series = await _unitofwork.SeriesRepository.Get(request.SeriesId);
        if (series == null)
            throw new SeriesNotFoundException(nameof(series), request.SeriesId);


        return _mapper.Map<List<EpisodeListDto>>(series.Episodes);
    }
}
