using Herokume.Application.Dtos.Episode;
using MediatR;

namespace Herokume.Application.Features.Commands.Episode.Requests;

public class UpdateEpisode:IRequest
{
    public Guid Id { get; set; }
    public UpdateEpisodeDto UpdateEpisodeDto { get; set; }
}
