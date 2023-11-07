using Herokume.Application.Dtos.Episode;
using MediatR;

namespace Herokume.Application.Features.Commands.Episode.Requests;

public class CreateEpisode : IRequest<Guid>
{
    public Guid SeriesId { get; set; }
    public CreateEpisodeDto CreateEpisodeDto { get; set; }
}
