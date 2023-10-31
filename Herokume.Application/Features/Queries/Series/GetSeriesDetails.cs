using Herokume.Application.Dtos.Series;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokume.Application.Features.Queries.Series
{
    public class GetSeriesDetails : IRequest<SeriesDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
