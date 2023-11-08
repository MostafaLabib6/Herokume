using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Comment;
using Herokume.Application.Dtos.Comment.Validator;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Comment.Request;
using MediatR;

namespace Herokume.Application.Features.Commands.Comment.Handler;

public class CreateCommentHandler : IRequestHandler<CreateComment, Guid>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public CreateCommentHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateComment request, CancellationToken cancellationToken)
    {

        if (request.CreateCommentDto?.UserId == Guid.Empty)
            throw new Exception("User Not Found");

        var validator = new CreateCommentDtoValidator();
        var validatorResult = await validator.ValidateAsync(request.CreateCommentDto, cancellationToken);
        if (!validatorResult.IsValid)
            throw new Exception();

        //TODO: Adding user Repository
        var series = await _unitofWork.SeriesRepository.Get(request.CreateCommentDto.SeriesId);
        var episode = await _unitofWork.EpisodeRepository.Get(request.CreateCommentDto.EpisodeId);

        if (episode is null && series is null)
            throw new BadException("Series or Episode Error");

        // if empty episode will have empty guid 
        var comment = _mapper.Map<Domain.Entities.Comment>(request.CreateCommentDto);
        var ent = await _unitofWork.CommentRepository.Add(comment);
        return ent.ID;


    }
}
