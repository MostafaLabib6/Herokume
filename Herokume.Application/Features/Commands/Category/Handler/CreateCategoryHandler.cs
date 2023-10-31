using AutoMapper;
using Herokume.Application.Contracts.Persistance;
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
        var category = _mapper.Map<Domain.Entities.Category>(request.CreateCategoryDto);
        _categoryRepository.Add(category);
        bool valid = await _categoryRepository.Save();
        //if (valid) 
        return Unit.Value;
    }
}
