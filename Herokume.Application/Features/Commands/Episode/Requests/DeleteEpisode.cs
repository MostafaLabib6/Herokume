using MediatR;

namespace Herokume.Application.Features.Commands.Episode.Requests;

public class DeleteEpisode:IRequest
{
    public Guid Id { get; set; }
}
