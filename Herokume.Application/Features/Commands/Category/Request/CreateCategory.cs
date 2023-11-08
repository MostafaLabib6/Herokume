

using Herokume.Application.Dtos.Category;
using MediatR;
using System.Security.Principal;

namespace Herokume.Application.Features.Commands.Category.Request;

public class CreateCategory : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;

}
