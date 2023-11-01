using FluentValidation;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Series.Validator;

namespace Herokume.Application.Dtos.Episode.Validators;

public class CreateEpisodeDtoValidator : AbstractValidator<CreateEpisodeDto>
{
    private readonly IUnitofWork _unitofWork;

    public CreateEpisodeDtoValidator(IUnitofWork unitofWork)
    {
        _unitofWork = unitofWork;
        RuleFor(episode => episode.Name)
         .NotEmpty().WithMessage("{PropertyName} is Required")
         .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
         .NotNull();

        RuleFor(episode => episode.EpisodeURL)
         .NotEmpty().WithMessage("{PropertyName} is Required")
         .NotNull();

        RuleFor(episode => episode.Series)
            .SetValidator(new BaseSeriesDtoValidator(_unitofWork.SeriesRepository));

    }
}
