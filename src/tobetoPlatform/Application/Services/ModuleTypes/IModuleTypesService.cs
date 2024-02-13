using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ModuleTypes;

public interface IModuleTypesService
{
    Task<ModuleType?> GetAsync(
        Expression<Func<ModuleType, bool>> predicate,
        Func<IQueryable<ModuleType>, IIncludableQueryable<ModuleType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ModuleType>?> GetListAsync(
        Expression<Func<ModuleType, bool>>? predicate = null,
        Func<IQueryable<ModuleType>, IOrderedQueryable<ModuleType>>? orderBy = null,
        Func<IQueryable<ModuleType>, IIncludableQueryable<ModuleType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ModuleType> AddAsync(ModuleType moduleType);
    Task<ModuleType> UpdateAsync(ModuleType moduleType);
    Task<ModuleType> DeleteAsync(ModuleType moduleType, bool permanent = false);
}
