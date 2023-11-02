using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Category.Validators;
using Herokume.Application.Dtos.Episode.Validators;
using Herokume.Application.Features.Commands.Episode.Requests;
using MediatR;

namespace Herokume.Application.Features.Commands.Episode.Handlers;

public class CreateEpisodeHandler : IRequestHandler<CreateEpisode, Unit>
{
    //private readonly IEpisodeRepository _episodeRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public CreateEpisodeHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateEpisode request, CancellationToken cancellationToken)
    {
        var validator = new CreateEpisodeDtoValidator(_unitofWork);
        var validatorResult = await validator.ValidateAsync(request.CreateEpisodeDto, cancellationToken);
        if (!validatorResult.IsValid)
            throw new Exception();

        var Episode = _mapper.Map<Domain.Entities.Episode>(request.CreateEpisodeDto);
        _unitofWork.EpisodeRepository.Add(Episode);
        //if (valid) 
        return Unit.Value;
    }
}
