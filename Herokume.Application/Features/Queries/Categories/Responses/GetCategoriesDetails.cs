using Herokume.Application.Dtos.Category;
using MediatR;

namespace Herokume.Application.Features.Queries.Categories.Responses;

public class GetCategoriesDetails:IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}
