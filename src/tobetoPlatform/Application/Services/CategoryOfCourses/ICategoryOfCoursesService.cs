using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryOfCourses;

public interface ICategoryOfCoursesService
{
    Task<CategoryOfCourse?> GetAsync(
        Expression<Func<CategoryOfCourse, bool>> predicate,
        Func<IQueryable<CategoryOfCourse>, IIncludableQueryable<CategoryOfCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CategoryOfCourse>?> GetListAsync(
        Expression<Func<CategoryOfCourse, bool>>? predicate = null,
        Func<IQueryable<CategoryOfCourse>, IOrderedQueryable<CategoryOfCourse>>? orderBy = null,
        Func<IQueryable<CategoryOfCourse>, IIncludableQueryable<CategoryOfCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CategoryOfCourse> AddAsync(CategoryOfCourse categoryOfCourse);
    Task<CategoryOfCourse> UpdateAsync(CategoryOfCourse categoryOfCourse);
    Task<CategoryOfCourse> DeleteAsync(CategoryOfCourse categoryOfCourse, bool permanent = false);
}
