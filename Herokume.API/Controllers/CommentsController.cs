using Herokume.Application.Dtos.Comment;
using Herokume.Application.Features.Commands.Comment.Request;
using Herokume.Application.Features.Queries.Comments.Requests;
using Herokume.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Principal;

namespace Herokume.API.Controllers;

[Route("api/")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;
    //private readonly ILogger _logger;

    public CommentsController(IMediator mediator/*, ILogger logger*/)
    {
        _mediator = mediator;
        //_logger = logger;
    }

    [HttpGet("series/{seriesId}/comments/", Name = "Series'sComments")]
    public async Task<ActionResult<List<CommentsListDto>>> GetSeriesComments(Guid seriesId)
    {
        var comments = await _mediator.Send(new GetCommentsListForSeries() { SeriesId = seriesId });
        return Ok(comments);
    }

    [HttpGet("episodes/{episodeId}/comments/", Name = "Episode'sComments")]
    public async Task<ActionResult<List<CommentsListDto>>> GetEpisodeComments(Guid episodeId)
    {
        var comments = await _mediator.Send(new GetCommentsListForEpisode() { EpisodeId = episodeId });
        return Ok(comments);
    }

    [HttpPost("series/{seriesId}/comments/")]
    public async Task<ActionResult<CreateCommentForSeriesDto>> CreateCommentForSeries(Guid seriesId, CommentDto comment)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
        var createCommentDto = new CreateCommentForSeriesDto
        {
            Content = comment.Content,
            UserId = new Guid(userId ?? throw new ArgumentNullException()),
            SeriesId = seriesId
        };

        var commentId = await _mediator.Send(new CreateCommentForSeries() { CreateCommentDto = createCommentDto });
        return CreatedAtRoute("Series'sComments", new { seriesId = seriesId, commentId = commentId }, createCommentDto);
    }

    [HttpPost("episodes/{episodeId}/comments/")]
    public async Task<ActionResult<CreateCommentForSeriesDto>> CreateCommentForEpisode(Guid episodeId, CommentDto comment)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
        var createCommentDto = new CreateCommentForEpisodeDto
        {
            Content = comment.Content,
            UserId = new Guid(userId ?? throw new ArgumentNullException()),
            EpisodeId = episodeId
        };

        var commentId = await _mediator.Send(new CreateCommentForEpisode() { CreateCommentDto = createCommentDto });
        return CreatedAtRoute("Episode'sComments", new { episodeId = episodeId, commentId = commentId }, createCommentDto);
    }

    [HttpPatch("Comments/{commentId}")]
    public async Task<IActionResult> IncreamentLikes(Guid commentId)
    {
        await _mediator.Send(new IncreamentLikes() { CommentId = commentId });
        return NoContent();
    }


    //[HttpDelete("series/{seriesId}/comments/commentId")]
    //[HttpDelete("episodes/{episodeId}/comments/commentId")]
    //public async Task<ActionResult> DeleteComment()
    //{
    //}
}


