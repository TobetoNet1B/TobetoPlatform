using Application.Features.CategoryOfModuleSets.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryOfModuleSets;

public class CategoryOfModuleSetsManager : ICategoryOfModuleSetsService
{
    private readonly ICategoryOfModuleSetRepository _categoryOfModuleSetRepository;
    private readonly CategoryOfModuleSetBusinessRules _categoryOfModuleSetBusinessRules;

    public CategoryOfModuleSetsManager(ICategoryOfModuleSetRepository categoryOfModuleSetRepository, CategoryOfModuleSetBusinessRules categoryOfModuleSetBusinessRules)
    {
        _categoryOfModuleSetRepository = categoryOfModuleSetRepository;
        _categoryOfModuleSetBusinessRules = categoryOfModuleSetBusinessRules;
    }

    public async Task<CategoryOfModuleSet?> GetAsync(
        Expression<Func<CategoryOfModuleSet, bool>> predicate,
        Func<IQueryable<CategoryOfModuleSet>, IIncludableQueryable<CategoryOfModuleSet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CategoryOfModuleSet? categoryOfModuleSet = await _categoryOfModuleSetRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return categoryOfModuleSet;
    }

    public async Task<IPaginate<CategoryOfModuleSet>?> GetListAsync(
        Expression<Func<CategoryOfModuleSet, bool>>? predicate = null,
        Func<IQueryable<CategoryOfModuleSet>, IOrderedQueryable<CategoryOfModuleSet>>? orderBy = null,
        Func<IQueryable<CategoryOfModuleSet>, IIncludableQueryable<CategoryOfModuleSet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CategoryOfModuleSet> categoryOfModuleSetList = await _categoryOfModuleSetRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return categoryOfModuleSetList;
    }

    public async Task<CategoryOfModuleSet> AddAsync(CategoryOfModuleSet categoryOfModuleSet)
    {
        CategoryOfModuleSet addedCategoryOfModuleSet = await _categoryOfModuleSetRepository.AddAsync(categoryOfModuleSet);

        return addedCategoryOfModuleSet;
    }

    public async Task<CategoryOfModuleSet> UpdateAsync(CategoryOfModuleSet categoryOfModuleSet)
    {
        CategoryOfModuleSet updatedCategoryOfModuleSet = await _categoryOfModuleSetRepository.UpdateAsync(categoryOfModuleSet);

        return updatedCategoryOfModuleSet;
    }

    public async Task<CategoryOfModuleSet> DeleteAsync(CategoryOfModuleSet categoryOfModuleSet, bool permanent = false)
    {
        CategoryOfModuleSet deletedCategoryOfModuleSet = await _categoryOfModuleSetRepository.DeleteAsync(categoryOfModuleSet);

        return deletedCategoryOfModuleSet;
    }
}
