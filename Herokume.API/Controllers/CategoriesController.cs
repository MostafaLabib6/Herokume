using Herokume.Application.Dtos.Category;
using Herokume.Application.Features.Commands.Category.Request;
using Herokume.Application.Features.Queries.Categories.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Herokume.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [HttpHead()]
    public async Task<ActionResult<List<CategoryListDto>>> GetCategories()
    {
        var categories = await _mediator.Send(new GetCategoriesList());
        return Ok(categories);
    }

    [HttpGet("{id}", Name = "GetCategory")]
    [HttpHead("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
    {
        var category = await _mediator.Send(new GetCategoriesDetails() { Id = id });
        return Ok(category);
    }

    [HttpPost("{name}")]
    public async Task<ActionResult<string>> CreateCategory(string name)
    {
        var id = await _mediator.Send(new CreateCategory() { Name = name });
        return CreatedAtRoute("GetCategory", new { id }, name);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(Guid id)
    {
        await _mediator.Send(new DeleteCategory() { Id = id });
        return NoContent();
    }

    [HttpOptions()]
    public IActionResult GetCategoryOptions()
    {
        Response.Headers.Add("Allow", "GET,HEAD,POST,OPTIONS");
        return Ok();
    }
}
