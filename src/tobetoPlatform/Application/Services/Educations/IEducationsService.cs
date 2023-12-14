using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Educations;

public interface IEducationsService
{
    Task<Education?> GetAsync(
        Expression<Func<Education, bool>> predicate,
        Func<IQueryable<Education>, IIncludableQueryable<Education, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Education>?> GetListAsync(
        Expression<Func<Education, bool>>? predicate = null,
        Func<IQueryable<Education>, IOrderedQueryable<Education>>? orderBy = null,
        Func<IQueryable<Education>, IIncludableQueryable<Education, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Education> AddAsync(Education education);
    Task<Education> UpdateAsync(Education education);
    Task<Education> DeleteAsync(Education education, bool permanent = false);
}
