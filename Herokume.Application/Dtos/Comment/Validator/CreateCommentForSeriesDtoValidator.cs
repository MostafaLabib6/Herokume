using FluentValidation;

namespace Herokume.Application.Dtos.Comment.Validator;

public class CreateCommentForSeriesDtoValidator:AbstractValidator<CreateCommentForSeriesDto>
{
    public CreateCommentForSeriesDtoValidator()
    {
         RuleFor(comment => comment.Content)
            .NotEmpty().WithMessage("{PropertyName} is Required")
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.")
            .NotNull();
    }
}
