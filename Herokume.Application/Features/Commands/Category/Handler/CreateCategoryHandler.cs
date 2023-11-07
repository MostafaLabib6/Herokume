using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Category.Validators;
using Herokume.Application.Features.Commands.Category.Request;
using MediatR;

namespace Herokume.Application.Features.Commands.Category.Handler;

public class CreateCategoryHandler : IRequestHandler<CreateCategory, Unit>
{

    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(CreateCategory request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryDtoValidator();
        var validatorResualt = await validator.ValidateAsync(request.Name, cancellationToken);

        if (!validatorResualt.IsValid)
            throw new Exception();

        Domain.Entities.Category category = new()
        {
            Name = request.Name,
        };
        await _categoryRepository.Add(category);

        return Unit.Value;
    }
}
