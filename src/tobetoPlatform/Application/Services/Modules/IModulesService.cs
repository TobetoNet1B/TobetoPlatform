using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Modules;

public interface IModulesService
{
    Task<Module?> GetAsync(
        Expression<Func<Module, bool>> predicate,
        Func<IQueryable<Module>, IIncludableQueryable<Module, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Module>?> GetListAsync(
        Expression<Func<Module, bool>>? predicate = null,
        Func<IQueryable<Module>, IOrderedQueryable<Module>>? orderBy = null,
        Func<IQueryable<Module>, IIncludableQueryable<Module, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Module> AddAsync(Module module);
    Task<Module> UpdateAsync(Module module);
    Task<Module> DeleteAsync(Module module, bool permanent = false);
}
