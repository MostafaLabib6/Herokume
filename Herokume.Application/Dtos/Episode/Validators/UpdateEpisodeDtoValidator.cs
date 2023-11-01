using FluentValidation;

namespace Herokume.Application.Dtos.Episode.Validators;

public class UpdateEpisodeDtoValidator:AbstractValidator<UpdateEpisodeDto>
{
    public UpdateEpisodeDtoValidator()
    {
         RuleFor(episode => episode.Name)
         .NotEmpty().WithMessage("{PropertyName} is Required")
         .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
         .NotNull();

        RuleFor(episode => episode.EpisodeUrl)
         .NotEmpty().WithMessage("{PropertyName} is Required")
         .NotNull();
    }
}
