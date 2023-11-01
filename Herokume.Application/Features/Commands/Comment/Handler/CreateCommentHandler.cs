using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Comment;
using Herokume.Application.Dtos.Comment.Validator;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Comment.Request;
using MediatR;

namespace Herokume.Application.Features.Commands.Comment.Handler;

public class CreateCommentHandler : IRequestHandler<CreateComment, Unit>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public CreateCommentHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateComment request, CancellationToken cancellationToken)
    {
        var validator = new CreateCommentDtoValidator();
        var validatorResult = await validator.ValidateAsync(request.CreateCommentDto, cancellationToken);
        if (!validatorResult.IsValid)
            throw new Exception();

        //TODO: Adding user Repository
        var series = await _unitofWork.SeriesRepository.Get(request.SeriesId);
        var episode = await _unitofWork.EpisodeRepository.Get(request.EpisodeId);

        if (episode is null && series is null) 
               throw new BadException("Series or Episode Error");
        var comment = _mapper.Map<Domain.Entities.Comment>(request.CreateCommentDto);
        _unitofWork.CommentRepository.Add(comment);
        await _unitofWork.CommentRepository.Save();
        return Unit.Value;
    }
}
