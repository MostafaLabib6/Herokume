using FluentValidation;

namespace Herokume.Application.Dtos.Comment.Validator;

public class CreateCommentDtoValidator:AbstractValidator<CreateCommentDto>
{
    public CreateCommentDtoValidator()
    {
         RuleFor(comment => comment.Content)
            .NotEmpty().WithMessage("{PropertyName} is Required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
            .NotNull();
    }
}
