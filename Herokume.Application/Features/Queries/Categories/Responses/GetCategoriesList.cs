using Herokume.Application.Dtos.Category;
using MediatR;

namespace Herokume.Application.Features.Queries.Categories.Responses;

public class GetCategoriesList:IRequest<List<CategoryListDto>>
{
}
