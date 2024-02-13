using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryOfModuleSets;

public interface ICategoryOfModuleSetsService
{
    Task<CategoryOfModuleSet?> GetAsync(
        Expression<Func<CategoryOfModuleSet, bool>> predicate,
        Func<IQueryable<CategoryOfModuleSet>, IIncludableQueryable<CategoryOfModuleSet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CategoryOfModuleSet>?> GetListAsync(
        Expression<Func<CategoryOfModuleSet, bool>>? predicate = null,
        Func<IQueryable<CategoryOfModuleSet>, IOrderedQueryable<CategoryOfModuleSet>>? orderBy = null,
        Func<IQueryable<CategoryOfModuleSet>, IIncludableQueryable<CategoryOfModuleSet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CategoryOfModuleSet> AddAsync(CategoryOfModuleSet categoryOfModuleSet);
    Task<CategoryOfModuleSet> UpdateAsync(CategoryOfModuleSet categoryOfModuleSet);
    Task<CategoryOfModuleSet> DeleteAsync(CategoryOfModuleSet categoryOfModuleSet, bool permanent = false);
}
