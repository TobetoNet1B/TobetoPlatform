using Application.Features.ModuleSetCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ModuleSetCategories;

public class ModuleSetCategoriesManager : IModuleSetCategoriesService
{
    private readonly IModuleSetCategoryRepository _moduleSetCategoryRepository;
    private readonly ModuleSetCategoryBusinessRules _moduleSetCategoryBusinessRules;

    public ModuleSetCategoriesManager(IModuleSetCategoryRepository moduleSetCategoryRepository, ModuleSetCategoryBusinessRules moduleSetCategoryBusinessRules)
    {
        _moduleSetCategoryRepository = moduleSetCategoryRepository;
        _moduleSetCategoryBusinessRules = moduleSetCategoryBusinessRules;
    }

    public async Task<ModuleSetCategory?> GetAsync(
        Expression<Func<ModuleSetCategory, bool>> predicate,
        Func<IQueryable<ModuleSetCategory>, IIncludableQueryable<ModuleSetCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ModuleSetCategory? moduleSetCategory = await _moduleSetCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return moduleSetCategory;
    }

    public async Task<IPaginate<ModuleSetCategory>?> GetListAsync(
        Expression<Func<ModuleSetCategory, bool>>? predicate = null,
        Func<IQueryable<ModuleSetCategory>, IOrderedQueryable<ModuleSetCategory>>? orderBy = null,
        Func<IQueryable<ModuleSetCategory>, IIncludableQueryable<ModuleSetCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ModuleSetCategory> moduleSetCategoryList = await _moduleSetCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return moduleSetCategoryList;
    }

    public async Task<ModuleSetCategory> AddAsync(ModuleSetCategory moduleSetCategory)
    {
        ModuleSetCategory addedModuleSetCategory = await _moduleSetCategoryRepository.AddAsync(moduleSetCategory);

        return addedModuleSetCategory;
    }

    public async Task<ModuleSetCategory> UpdateAsync(ModuleSetCategory moduleSetCategory)
    {
        ModuleSetCategory updatedModuleSetCategory = await _moduleSetCategoryRepository.UpdateAsync(moduleSetCategory);

        return updatedModuleSetCategory;
    }

    public async Task<ModuleSetCategory> DeleteAsync(ModuleSetCategory moduleSetCategory, bool permanent = false)
    {
        ModuleSetCategory deletedModuleSetCategory = await _moduleSetCategoryRepository.DeleteAsync(moduleSetCategory);

        return deletedModuleSetCategory;
    }
}
