using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Features.Commands.Comment.Request;
using MediatR;
using System.Runtime.InteropServices;

namespace Herokume.Application.Features.Commands.Comment.Handler;

public class DeleteCommentHandler : IRequestHandler<DeleteComment, Unit>
{
    private readonly IUnitofWork _unitofWork;


    public DeleteCommentHandler(IUnitofWork unitofWork)
    {
        _unitofWork = unitofWork;
    }
    public async Task<Unit> Handle(DeleteComment request, CancellationToken cancellationToken)
    {
        if (request.UserId == Guid.Empty)
            throw new Exception("User Not Found");

        var comment = await _unitofWork.CommentRepository.Get(request.CommentId);
        if (comment == null)
            throw new Exception($"{nameof(comment)} {request.CommentId}");


        await _unitofWork.CommentRepository.Delete(comment);
        return Unit.Value;
    }
}
