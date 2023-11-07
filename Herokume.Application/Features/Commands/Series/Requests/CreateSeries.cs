using Herokume.Application.Dtos.Series;
using MediatR;

namespace Herokume.Application.Features.Commands.Series.Requests;

public class CreateSeries : IRequest<Guid>
{
   public CreateSeriesDto CreateSeriesDto { get; set; }
}
