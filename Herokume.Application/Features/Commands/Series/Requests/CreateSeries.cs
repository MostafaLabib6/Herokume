using Herokume.Application.Dtos.Series;
using MediatR;

namespace Herokume.Application.Features.Commands.Series.Requests;

public class CreateSeries : IRequest
{
   public CreateSeriesDto CreateSeriesDto { get; set; }
}
