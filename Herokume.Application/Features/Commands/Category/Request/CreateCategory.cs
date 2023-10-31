

using Herokume.Application.Dtos.Category;
using MediatR;
using System.Security.Principal;

namespace Herokume.Application.Features.Commands.Category.Request;

public class CreateCategory : IRequest
{
    public CreateCategoryDto CreateCategoryDto { get; set; }
}
