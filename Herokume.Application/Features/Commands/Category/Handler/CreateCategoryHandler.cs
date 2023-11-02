using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Category.Validators;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Category.Request;
using MediatR;

namespace Herokume.Application.Features.Commands.Category.Handler;

public class CreateCategoryHandler : IRequestHandler<CreateCategory, Unit>
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly Mapper _mapper;

    public CreateCategoryHandler(ICategoryRepository categoryRepository, Mapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateCategory request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryDtoValidator();
        var validatorResualt =await  validator.ValidateAsync(request.CreateCategoryDto, cancellationToken);

        if(!validatorResualt.IsValid)
            throw new Exception();
        var category = _mapper.Map<Domain.Entities.Category>(request.CreateCategoryDto);
        _categoryRepository.Add(category);
        //if (valid) 
        return Unit.Value;
    }
}
