using MediatR;

namespace Herokume.Application.Features.Commands.Series.Requests
{
    public class DeleteSeries:IRequest
    {
        public Guid Id { get; set; }
    }
}
