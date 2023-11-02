using Herokume.Application.Dtos.Series;
using MediatR;

namespace Herokume.Application.Features.Commands.Series.Requests;

public class CreateSeries : IRequest
{
   public BaseSeriesDto CreateSeriesDto { get; set; }
}
