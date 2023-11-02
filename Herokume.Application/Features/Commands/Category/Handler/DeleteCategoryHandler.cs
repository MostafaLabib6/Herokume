using AutoMapper;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Exceptions;
using Herokume.Application.Features.Commands.Category.Request;
using MediatR;

namespace Herokume.Application.Features.Commands.Category.Handler;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly Mapper _mapper;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository, Mapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteCategory request, CancellationToken cancellationToken)
    {
         var category = await _categoryRepository.Get(request.Id);
        if (category == null)
            throw new EpsiodeNotFoundException(nameof(category), request.Id);
        _categoryRepository.Delete(category);
        return Unit.Value;
    }
}
