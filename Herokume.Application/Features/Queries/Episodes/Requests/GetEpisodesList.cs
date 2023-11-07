using Herokume.Application.Dtos.Episode;
using MediatR;

namespace Herokume.Application.Features.Queries.Episodes.Requests;

public class GetEpisodesList:IRequest<List<EpisodeListDto>>
{
    public Guid SeriesId { get; set; }
}
