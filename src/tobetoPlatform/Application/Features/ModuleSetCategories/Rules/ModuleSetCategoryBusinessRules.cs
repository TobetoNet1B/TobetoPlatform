using Application.Features.ModuleSetCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ModuleSetCategories.Rules;

public class ModuleSetCategoryBusinessRules : BaseBusinessRules
{
    private readonly IModuleSetCategoryRepository _moduleSetCategoryRepository;

    public ModuleSetCategoryBusinessRules(IModuleSetCategoryRepository moduleSetCategoryRepository)
    {
        _moduleSetCategoryRepository = moduleSetCategoryRepository;
    }

    public Task ModuleSetCategoryShouldExistWhenSelected(ModuleSetCategory? moduleSetCategory)
    {
        if (moduleSetCategory == null)
            throw new BusinessException(ModuleSetCategoriesBusinessMessages.ModuleSetCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task ModuleSetCategoryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ModuleSetCategory? moduleSetCategory = await _moduleSetCategoryRepository.GetAsync(
            predicate: msc => msc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ModuleSetCategoryShouldExistWhenSelected(moduleSetCategory);
    }
}