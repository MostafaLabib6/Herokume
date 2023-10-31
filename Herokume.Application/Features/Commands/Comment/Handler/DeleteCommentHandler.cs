using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Features.Commands.Comment.Request;
using MediatR;
using System.Runtime.InteropServices;

namespace Herokume.Application.Features.Commands.Comment.Handler;

public class DeleteCommentHandler : IRequestHandler<DeleteComment, Unit>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public DeleteCommentHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteComment request, CancellationToken cancellationToken)
    {
        var comment = await _unitofWork.CommentRepository.Get(request.CommentId);
        if (comment == null)
            throw new Exception($"{nameof(comment)} {request.CommentId}");
        _unitofWork.CommentRepository.Delete(comment);
        await _unitofWork.CommentRepository.Save();
        return Unit.Value;
    }
}
