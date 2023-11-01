using FluentValidation;
using Herokume.Application.Contracts.Persistance;

namespace Herokume.Application.Dtos.Series.Validator;

public class BaseSeriesDtoValidator : AbstractValidator<BaseSeriesDto>
{
    private readonly ISeriesRepository _seriesRepository;

    public BaseSeriesDtoValidator(ISeriesRepository seriesRepository)
    {
        _seriesRepository = seriesRepository;
        RuleFor(series => series.Name)
          .NotEmpty().WithMessage("{PropertyName} is Required")
          .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonVa1ue} characters.")
          .NotNull();

        RuleFor(series => series.Id)
            .MustAsync(async (Id, token) =>
            {
                return await _seriesRepository.Exist(Id);
            });

    }
}
