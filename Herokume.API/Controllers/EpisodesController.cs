using Herokume.Application.Dtos.Episode;
using Herokume.Application.Dtos.Series;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Episode.Requests;
using Herokume.Application.Features.Commands.Series.Requests;
using Herokume.Application.Features.Queries.Episodes.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Herokume.API.Controllers;

[Route("api/series/{seriesId}/episodes")]
[ApiController]
public class EpisodesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EpisodesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    [HttpHead]
    public async Task<ActionResult<List<EpisodeListDto>>> GetEpisodes(Guid seriesId)
    {
        var episodes = await _mediator.Send(new GetEpisodesList() { SeriesId = seriesId });
        return Ok(episodes);
    }

    [HttpGet("{episodeId}", Name = "GetEpisodeDetails")]
    [HttpHead("{episodeId}")]
    public async Task<ActionResult<EpisodeDetailsDto>> GetEpisode(Guid seriesId, Guid episodeId)
    {
        var episode = await _mediator.Send(new GetEpisodeDetails() { SeriesId = seriesId, Id = episodeId });
        return Ok(episode);
    }

    [HttpPost]
    public async Task<ActionResult<CreateEpisodeDto>> CreateEpisode(Guid seriesId, CreateEpisodeDto createEpisodeDto)
    {
        var episodeId = await _mediator.Send(new CreateEpisode() { SeriesId = seriesId, CreateEpisodeDto = createEpisodeDto });
        return CreatedAtRoute("GetEpisodeDetails", new { SeriesId = seriesId, EpisodeId = episodeId }, createEpisodeDto);
    }

    [HttpPut("{episodeId}")]
    public async Task<ActionResult> UpdateEpisode(Guid seriesId, Guid episodeId, UpdateEpisodeDto updateEpisodeDto)
    {
        //TODO: implemeant upsert
        await _mediator.Send(new UpdateEpisode() { SeriesId = seriesId, Id = episodeId, UpdateEpisodeDto = updateEpisodeDto });
        return NoContent();
    }

    [HttpDelete("{episodeId}")]
    public async Task<ActionResult> DeleteEpisode(Guid seriesId, Guid episodeId)
    {
        await _mediator.Send(new DeleteEpisode() { SeriesId = seriesId, Id = episodeId });
        return NoContent();
    }

    [HttpOptions()]
    public IActionResult GetEpisodeOptions()
    {
        Response.Headers.Add("Allow", "GET,HEAD,POST,PUT,OPTIONS");
        return Ok();
    }

}
