using FluentValidation;

namespace Herokume.Application.Dtos.Category.Validators;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(category => category.Name)
            .NotEmpty().WithMessage("{PropertyName} is Required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
            .NotNull();
    }
}
