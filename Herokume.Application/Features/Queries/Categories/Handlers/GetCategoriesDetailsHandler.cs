using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Category;
using Herokume.Application.Features.Queries.Categories.Responses;
using MediatR;

namespace Herokume.Application.Features.Queries.Categories.Handlers;

public class GetCategoriesDetailsHandler : IRequestHandler<GetCategoriesDetails, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesDetailsHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoriesDetails request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.Get(request.Id);
        if (category == null)
            throw new Exceptions.CategoryNotFoundException(nameof(category), request.Id);
        return _mapper.Map<CategoryDto>(category);
    }
}
