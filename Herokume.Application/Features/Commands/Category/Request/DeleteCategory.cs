using MediatR;

namespace Herokume.Application.Features.Commands.Category.Request;

public class DeleteCategory:IRequest
{
    public Guid Id { get; set; }
}
