using Herokume.Application.Dtos.Series;
using Herokume.Application.Features.Commands.Series.Requests;
using Herokume.Application.Features.Queries.Series;
using Herokume.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Herokume.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<SeriesListDto>>> GetSeries()
        {
            var series = await _mediator.Send(new GetSeriesList());
            if (series == null)
                return BadRequest();
            return Ok(series);
        }

        [HttpGet("countofRandomSeries/{count}")]
        public async Task<ActionResult<List<SeriesListDto>>> GetRandomSeries(int count)
        {
            var series = await _mediator.Send(new GetRandomSeries() { Count = count });
            return Ok(series);
        }

        [HttpGet("{id}/episodesCounts")]
        public async Task<ActionResult<int>> GetNumberofEpisodesinSeries(Guid id)
        {
            var episodesCount = await _mediator.Send(new GetNumberofEpisodesinSeries() { Id = id });
            return Ok(episodesCount);
        }

        [HttpGet("{id}", Name = "GetSeriesWithDetails")]
        [HttpHead("{id}")]
        public async Task<ActionResult<SeriesDetailsDto>> GetSeriesById(Guid id)
        {
            var series = await _mediator.Send(new GetSeriesDetails() { Id = id });
            if (series == null)
                return BadRequest();
            return Ok(series);
        }

        //[HttpGet("search/{name}")]
        //public async Task<ActionResult<SeriesDetailsDto>> GetSeriesByName(string name)
        //{
        //    //var series = await _mediator.Send(new GetSeriesDetails() { name });
        //    //if (series == null)
        //    //    return BadRequest();
        //    //return Ok(series);
        //}

        [HttpPost]
        public async Task<ActionResult<CreateSeriesDto>> CreateSeries([FromBody] CreateSeriesDto createSeriesDto)
        {
            var seriesId = await _mediator.Send(new CreateSeries() { CreateSeriesDto = createSeriesDto });

            return CreatedAtRoute("GetSeriesWithDetails", // Endpoint name to return to it.
                new { seriesId }, // id to end point
                createSeriesDto); // dto
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSeries(Guid id, UpdateSeriesDto updateSeriesDto)
        {
            //TODO: implemeant upsert
            await _mediator.Send(new UpdateSeries() { Id = id, UpdateSeriesDto = updateSeriesDto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeries(Guid id)
        {
            await _mediator.Send(new DeleteSeries() { Id = id });
            return NoContent();
        }

        [HttpOptions()]
        public IActionResult GetSeriesOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,POST,PUT,OPTIONS");
            return Ok();
        }
    }
}
