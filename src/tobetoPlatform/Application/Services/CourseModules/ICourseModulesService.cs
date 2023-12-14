using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseModules;

public interface ICourseModulesService
{
    Task<CourseModule?> GetAsync(
        Expression<Func<CourseModule, bool>> predicate,
        Func<IQueryable<CourseModule>, IIncludableQueryable<CourseModule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CourseModule>?> GetListAsync(
        Expression<Func<CourseModule, bool>>? predicate = null,
        Func<IQueryable<CourseModule>, IOrderedQueryable<CourseModule>>? orderBy = null,
        Func<IQueryable<CourseModule>, IIncludableQueryable<CourseModule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CourseModule> AddAsync(CourseModule courseModule);
    Task<CourseModule> UpdateAsync(CourseModule courseModule);
    Task<CourseModule> DeleteAsync(CourseModule courseModule, bool permanent = false);
}
