using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Comment;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Queries.Comments.Requests;
using MediatR;

namespace Herokume.Application.Features.Queries.Comments.Handlers;

public class GetCommentsListForSeriesHandler : IRequestHandler<GetCommentsListForSeries, List<CommentsListDto>>
{

    private readonly IUnitofWork _unitofwork;
    private readonly IMapper _mapper;

    public GetCommentsListForSeriesHandler(IUnitofWork unitofwork, IMapper mapper)
    {
        _unitofwork = unitofwork;
        _mapper = mapper;
    }

    public async Task<List<CommentsListDto>> Handle(GetCommentsListForSeries request, CancellationToken cancellationToken)
    {
        var series = await _unitofwork.SeriesRepository.Get(request.SeriesId);
        if (series == null)
            throw new SeriesNotFoundException(nameof(series), request.SeriesId);

        return _mapper.Map<List<CommentsListDto>>(series.Comments);
    }

}
