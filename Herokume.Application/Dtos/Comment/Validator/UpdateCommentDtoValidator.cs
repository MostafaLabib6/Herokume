using FluentValidation;

namespace Herokume.Application.Dtos.Comment.Validator;

public class UpdateCommentDtoValidator:AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentDtoValidator()
    {
           RuleFor(comment => comment.Content)
            .NotEmpty().WithMessage("{PropertyName} is Required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
            .NotNull();
    }
}
