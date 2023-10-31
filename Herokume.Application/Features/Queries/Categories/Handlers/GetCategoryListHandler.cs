using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Category;
using Herokume.Application.Features.Queries.Categories.Responses;
using MediatR;

namespace Herokume.Application.Features.Queries.Categories.Handlers;

public class GetCategoryListHandler : IRequestHandler<GetCategoriesList, List<CategoryListDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryListHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryListDto>> Handle(GetCategoriesList request, CancellationToken cancellationToken)
    {
        var Categories = await _categoryRepository.GetAll();
        return _mapper.Map<List<CategoryListDto>>(Categories);
    }
}
