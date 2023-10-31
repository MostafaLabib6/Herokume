
using Herokume.Application.Dtos.Episode;
using MediatR;

namespace Herokume.Application.Features.Queries.Episodes.Requests;

public class GetEpisodeDetails : IRequest<EpisodeDetailsDto>
{
    public Guid Id { get; set; }
}
