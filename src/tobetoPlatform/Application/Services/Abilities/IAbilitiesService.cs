using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Abilities;

public interface IAbilitiesService
{
    Task<Ability?> GetAsync(
        Expression<Func<Ability, bool>> predicate,
        Func<IQueryable<Ability>, IIncludableQueryable<Ability, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Ability>?> GetListAsync(
        Expression<Func<Ability, bool>>? predicate = null,
        Func<IQueryable<Ability>, IOrderedQueryable<Ability>>? orderBy = null,
        Func<IQueryable<Ability>, IIncludableQueryable<Ability, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Ability> AddAsync(Ability ability);
    Task<Ability> UpdateAsync(Ability ability);
    Task<Ability> DeleteAsync(Ability ability, bool permanent = false);
}
