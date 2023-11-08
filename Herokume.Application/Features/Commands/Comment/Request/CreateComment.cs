using Herokume.Application.Dtos.Comment;
using MediatR;

namespace Herokume.Application.Features.Commands.Comment.Request;

public class CreateComment : IRequest<Guid>
{

    public CreateCommentDto? CreateCommentDto { get; set; }
}
