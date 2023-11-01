using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Category.Validators;
using Herokume.Application.Dtos.Episode.Validators;
using Herokume.Application.Features.Commands.Episode.Requests;
using MediatR;

namespace Herokume.Application.Features.Commands.Episode.Handlers;

public class CreateEpisodeHandler : IRequestHandler<CreateEpisode, Unit>
{
      private readonly IEpisodeRepository _episodeRepository;
    private readonly IMapper _mapper;

    public CreateEpisodeHandler(IEpisodeRepository episodeRepository, IMapper mapper)
    {
        _episodeRepository = episodeRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateEpisode request, CancellationToken cancellationToken)
    {
         var validator = new CreateEpisodeDtoValidator();
         var validatorResult = await validator.ValidateAsync(request.CreateEpisodeDto,cancellationToken);
         if(!validatorResult.IsValid) 
            throw new Exception();

         var Episode = _mapper.Map<Domain.Entities.Episode>(request.CreateEpisodeDto);
        _episodeRepository.Add(Episode);
        bool valid = await _episodeRepository.Save();
        //if (valid) 
        return Unit.Value;
    }
}
