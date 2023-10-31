using Herokume.Application.Dtos.Episode;
using MediatR;

namespace Herokume.Application.Features.Commands.Episode.Requests;

public class CreateEpisode:IRequest
{
    public CreateEpisodeDto CreateEpisodeDto{ get; set; }
}
