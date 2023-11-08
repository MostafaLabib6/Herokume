using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Comment;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Queries.Comments.Requests;
using MediatR;

namespace Herokume.Application.Features.Queries.Comments.Handlers;

public class GetCommentsListForEpisodeHandler : IRequestHandler<GetCommentsListForEpisode, List<CommentsListDto>>
{

    private readonly IUnitofWork _unitofwork;
    private readonly IMapper _mapper;

    public GetCommentsListForEpisodeHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofwork = unitofWork;
        _mapper = mapper;
    }

    public async Task<List<CommentsListDto>> Handle(GetCommentsListForEpisode request, CancellationToken cancellationToken)
    {
        var episode = await _unitofwork.EpisodeRepository.Get(request.EpisodeId);
        if (episode == null)
            throw new EpsiodeNotFoundException(nameof(episode), request.EpisodeId);

        return _mapper.Map<List<CommentsListDto>>(episode.Comments);
    }
}
