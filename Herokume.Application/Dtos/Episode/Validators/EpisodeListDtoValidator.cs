using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokume.Application.Dtos.Episode.Validators
{
    // Create that to validate episode list in series
    public class EpisodeListDtoValidator : AbstractValidator<EpisodeListDto>
    {
        public EpisodeListDtoValidator()
        {
            RuleFor(episode => episode.Name)
             .NotEmpty().WithMessage("{PropertyName} is Required")
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
             .NotNull();

            RuleFor(episode => episode.EpisodeURL)
             .NotEmpty().WithMessage("{PropertyName} is Required")
             .NotNull();

            RuleFor(episode => episode.EpisodeNumber)
             .GreaterThan(0).WithMessage("{PropertyName} Must Be valid")
             .NotNull();
        }
    }
}
