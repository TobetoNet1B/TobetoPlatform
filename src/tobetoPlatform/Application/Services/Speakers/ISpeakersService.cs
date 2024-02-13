using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Speakers;

public interface ISpeakersService
{
    Task<Speaker?> GetAsync(
        Expression<Func<Speaker, bool>> predicate,
        Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Speaker>?> GetListAsync(
        Expression<Func<Speaker, bool>>? predicate = null,
        Func<IQueryable<Speaker>, IOrderedQueryable<Speaker>>? orderBy = null,
        Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Speaker> AddAsync(Speaker speaker);
    Task<Speaker> UpdateAsync(Speaker speaker);
    Task<Speaker> DeleteAsync(Speaker speaker, bool permanent = false);
}
