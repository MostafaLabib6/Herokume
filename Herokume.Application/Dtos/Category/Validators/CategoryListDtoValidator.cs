using FluentValidation;


namespace Herokume.Application.Dtos.Category.Validators
{
    public class CategoryListDtoValidator:AbstractValidator<CategoryListDto>
    {
        public CategoryListDtoValidator()
        {
              RuleFor(category => category.Name)
            .NotEmpty().WithMessage("{PropertyName} is Required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
            .NotNull();
        }
      
    }
}
