using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ModuleSets;

public interface IModuleSetsService
{
    Task<ModuleSet?> GetAsync(
        Expression<Func<ModuleSet, bool>> predicate,
        Func<IQueryable<ModuleSet>, IIncludableQueryable<ModuleSet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ModuleSet>?> GetListAsync(
        Expression<Func<ModuleSet, bool>>? predicate = null,
        Func<IQueryable<ModuleSet>, IOrderedQueryable<ModuleSet>>? orderBy = null,
        Func<IQueryable<ModuleSet>, IIncludableQueryable<ModuleSet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ModuleSet> AddAsync(ModuleSet moduleSet);
    Task<ModuleSet> UpdateAsync(ModuleSet moduleSet);
    Task<ModuleSet> DeleteAsync(ModuleSet moduleSet, bool permanent = false);
}
