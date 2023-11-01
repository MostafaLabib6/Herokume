using FluentValidation;
using Herokume.Application.Dtos.Category.Validators;
using Herokume.Application.Dtos.Episode;
using Herokume.Application.Dtos.Episode.Validators;
using Herokume.Application.Features.Commands.Episode.Handlers;
using Herokume.Domain.Entities;

namespace Herokume.Application.Dtos.Series.Validator;

public class CreateSeriesDtoValidator : AbstractValidator<CreateSeriesDto>
{
    public CreateSeriesDtoValidator()
    {
        RuleFor(series => series.Name)
       .NotEmpty().WithMessage("{PropertyName} is Required")
       .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
       .NotNull();

        //RuleFor(series => series.Trailer)
        // .NotEmpty().WithMessage("{PropertyName} is Required")
        // .NotNull();

        RuleFor(series => series.Image)
        .NotEmpty().WithMessage("{PropertyName} is Required")
        .NotNull();

        RuleFor(series => series.Description)
        .NotEmpty().WithMessage("{PropertyName} is Required")
        .MaximumLength(250).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
        .NotNull();

        RuleFor(series => series.CreatedAt)
        .Must((date, token) =>
        {
            if (date is DateTime)
                return true;
            else
                return false;
        }).WithMessage("{PropertyName} Must be Valid date")
        .NotNull();


        RuleForEach(series => series.Episodes).SetValidator(new EpisodeListDtoValidator());
        RuleForEach(series => series.categories).SetValidator(new CategoryListDtoValidator());

    }

}
