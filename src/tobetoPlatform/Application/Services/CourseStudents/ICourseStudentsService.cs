using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseStudents;

public interface ICourseStudentsService
{
    Task<CourseStudent?> GetAsync(
        Expression<Func<CourseStudent, bool>> predicate,
        Func<IQueryable<CourseStudent>, IIncludableQueryable<CourseStudent, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CourseStudent>?> GetListAsync(
        Expression<Func<CourseStudent, bool>>? predicate = null,
        Func<IQueryable<CourseStudent>, IOrderedQueryable<CourseStudent>>? orderBy = null,
        Func<IQueryable<CourseStudent>, IIncludableQueryable<CourseStudent, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CourseStudent> AddAsync(CourseStudent courseStudent);
    Task<CourseStudent> UpdateAsync(CourseStudent courseStudent);
    Task<CourseStudent> DeleteAsync(CourseStudent courseStudent, bool permanent = false);
}
