
using FluentValidation;
using Herokume.Application.Dtos.Category.Validators;
using Herokume.Application.Dtos.Episode.Validators;

namespace Herokume.Application.Dtos.Series.Validator;

public class UpdateSeriesDtoValidator:AbstractValidator<UpdateSeriesDto>
{
    public UpdateSeriesDtoValidator()
    {
        RuleFor(series => series.Name)
       .NotEmpty().WithMessage("{PropertyName} is Required")
       .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
       .NotNull();

        RuleFor(series => series.Image)
        .NotEmpty().WithMessage("{PropertyName} is Required")
        .NotNull();

        RuleFor(series => series.Description)
        .NotEmpty().WithMessage("{PropertyName} is Required")
        .MaximumLength(250).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
        .NotNull();

        RuleForEach(series => series.categories).SetValidator(new CategoryListDtoValidator());
    }
}
