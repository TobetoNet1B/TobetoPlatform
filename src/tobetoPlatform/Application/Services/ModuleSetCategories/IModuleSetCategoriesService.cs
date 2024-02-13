using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ModuleSetCategories;

public interface IModuleSetCategoriesService
{
    Task<ModuleSetCategory?> GetAsync(
        Expression<Func<ModuleSetCategory, bool>> predicate,
        Func<IQueryable<ModuleSetCategory>, IIncludableQueryable<ModuleSetCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ModuleSetCategory>?> GetListAsync(
        Expression<Func<ModuleSetCategory, bool>>? predicate = null,
        Func<IQueryable<ModuleSetCategory>, IOrderedQueryable<ModuleSetCategory>>? orderBy = null,
        Func<IQueryable<ModuleSetCategory>, IIncludableQueryable<ModuleSetCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ModuleSetCategory> AddAsync(ModuleSetCategory moduleSetCategory);
    Task<ModuleSetCategory> UpdateAsync(ModuleSetCategory moduleSetCategory);
    Task<ModuleSetCategory> DeleteAsync(ModuleSetCategory moduleSetCategory, bool permanent = false);
}
