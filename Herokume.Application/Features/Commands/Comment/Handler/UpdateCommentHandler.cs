using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Comment.Validator;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Comment.Request;
using MediatR;

namespace Herokume.Application.Features.Commands.Comment.Handler;

public class UpdateCommentHandler : IRequestHandler<EditComment, Unit>
{

    private readonly IUnitofWork _unitofWork;

    public UpdateCommentHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
    }

    public async Task<Unit> Handle(EditComment request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCommentDtoValidator();
        var validatorResult = await validator.ValidateAsync(request.UpdateCommentDto, cancellationToken);
        if (!validatorResult.IsValid)
            throw new Exception();

        if (request.UserId == Guid.Empty)
            throw new Exception("User Not Found");

        //TODO: Adding user Repository
        var series = await _unitofWork.SeriesRepository.Get(request.SeriesId);
        var episode = await _unitofWork.EpisodeRepository.Get(request.EpisodeId);

        if (episode is null && series is null)
            throw new BadException("Series or Episode Error");

        var comment = await _unitofWork.CommentRepository.Get(request.CommentId);
        comment.Content = request.UpdateCommentDto.Content;
        return Unit.Value;
    }

}

