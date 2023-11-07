using FluentValidation;

namespace Herokume.Application.Dtos.Category.Validators;

public class CreateCategoryDtoValidator : AbstractValidator<string>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("{PropertyName} is Required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
            .NotNull();
    }
}
