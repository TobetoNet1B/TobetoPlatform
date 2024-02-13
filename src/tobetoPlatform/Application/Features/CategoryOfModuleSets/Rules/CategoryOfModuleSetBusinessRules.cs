using Application.Features.CategoryOfModuleSets.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CategoryOfModuleSets.Rules;

public class CategoryOfModuleSetBusinessRules : BaseBusinessRules
{
    private readonly ICategoryOfModuleSetRepository _categoryOfModuleSetRepository;

    public CategoryOfModuleSetBusinessRules(ICategoryOfModuleSetRepository categoryOfModuleSetRepository)
    {
        _categoryOfModuleSetRepository = categoryOfModuleSetRepository;
    }

    public Task CategoryOfModuleSetShouldExistWhenSelected(CategoryOfModuleSet? categoryOfModuleSet)
    {
        if (categoryOfModuleSet == null)
            throw new BusinessException(CategoryOfModuleSetsBusinessMessages.CategoryOfModuleSetNotExists);
        return Task.CompletedTask;
    }

    public async Task CategoryOfModuleSetIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CategoryOfModuleSet? categoryOfModuleSet = await _categoryOfModuleSetRepository.GetAsync(
            predicate: coms => coms.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CategoryOfModuleSetShouldExistWhenSelected(categoryOfModuleSet);
    }
}