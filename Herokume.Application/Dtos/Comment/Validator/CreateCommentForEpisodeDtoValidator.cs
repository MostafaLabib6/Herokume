using FluentValidation;

namespace Herokume.Application.Dtos.Comment.Validator;

public class CreateCommentForEpisodeDtoValidator : AbstractValidator<CreateCommentForEpisodeDto>
{
    public CreateCommentForEpisodeDtoValidator()
    {
        RuleFor(comment => comment.Content)
           .NotEmpty().WithMessage("{PropertyName} is Required")
           .MaximumLength(1000).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.")
           .NotNull();
    }
}
