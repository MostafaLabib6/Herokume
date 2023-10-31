using Herokume.Application.Dtos.Series;
using MediatR;

namespace Herokume.Application.Features.Commands.Series.Requests;

public class UpdateSeries:IRequest
{
    public Guid Id { get; set; }
    public UpdateSeriesDto UpdateSeriesDto { get; set; }
}
