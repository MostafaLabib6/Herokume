using Herokume.Application.Dtos.Comment;
using Herokume.Application.Features.Commands.Comment.Request;
using Herokume.Application.Features.Queries.Comments.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Herokume.API.Controllers;

[Route("api/")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("series/{seriesId}/comments/")]
    public async Task<ActionResult<List<CommentsListDto>>> GetSeriesComments(Guid seriesId)
    {
        var comments = await _mediator.Send(new GetCommentsListForSeries() { SeriesId = seriesId });
        return Ok(comments);
    }

    [HttpGet("episodes/{episodeId}/comments/")]
    public async Task<ActionResult<List<CommentsListDto>>> GetEpisodeComments(Guid episodeId)
    {
        var comments = await _mediator.Send(new GetCommentsListForEpisode() { EpisodeId = episodeId });
        return Ok(comments);
    }

    [HttpPost("series/{seriesId}/comments/")]
    [HttpPost("episodes/{episodeId}/comments/")]
    public async Task<ActionResult<CreateCommentDto>> CreateComment(CreateCommentDto createCommentDto)
    {
        await _mediator.Send(new CreateComment() { CreateCommentDto = createCommentDto });
        return Ok(createCommentDto);// ok here because i did'nt implemanted Get() :)
    }

    //[HttpDelete("series/{seriesId}/comments/commentId")]
    //[HttpDelete("episodes/{episodeId}/comments/commentId")]
    //public async Task<ActionResult> DeleteComment()
    //{
    //}
}


