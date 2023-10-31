using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Comment;
using Herokume.Application.Features.Queries.Comments.Requests;
using MediatR;

namespace Herokume.Application.Features.Queries.Comments.Handlers;

public class GetCommentsListHandler : IRequestHandler<GetCommentsList, List<CommentsListDto>>
{
        
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentsListHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentsListDto>> Handle(GetCommentsList request, CancellationToken cancellationToken)
    {
        var comments =await _commentRepository.GetCommentsWithReplies();
        return _mapper.Map<List<CommentsListDto>>(comments);
    }
}
