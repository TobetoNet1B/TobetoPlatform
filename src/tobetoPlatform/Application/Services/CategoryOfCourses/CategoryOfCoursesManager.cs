using Application.Features.CategoryOfCourses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryOfCourses;

public class CategoryOfCoursesManager : ICategoryOfCoursesService
{
    private readonly ICategoryOfCourseRepository _categoryOfCourseRepository;
    private readonly CategoryOfCourseBusinessRules _categoryOfCourseBusinessRules;

    public CategoryOfCoursesManager(ICategoryOfCourseRepository categoryOfCourseRepository, CategoryOfCourseBusinessRules categoryOfCourseBusinessRules)
    {
        _categoryOfCourseRepository = categoryOfCourseRepository;
        _categoryOfCourseBusinessRules = categoryOfCourseBusinessRules;
    }

    public async Task<CategoryOfCourse?> GetAsync(
        Expression<Func<CategoryOfCourse, bool>> predicate,
        Func<IQueryable<CategoryOfCourse>, IIncludableQueryable<CategoryOfCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CategoryOfCourse? categoryOfCourse = await _categoryOfCourseRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return categoryOfCourse;
    }

    public async Task<IPaginate<CategoryOfCourse>?> GetListAsync(
        Expression<Func<CategoryOfCourse, bool>>? predicate = null,
        Func<IQueryable<CategoryOfCourse>, IOrderedQueryable<CategoryOfCourse>>? orderBy = null,
        Func<IQueryable<CategoryOfCourse>, IIncludableQueryable<CategoryOfCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CategoryOfCourse> categoryOfCourseList = await _categoryOfCourseRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return categoryOfCourseList;
    }

    public async Task<CategoryOfCourse> AddAsync(CategoryOfCourse categoryOfCourse)
    {
        CategoryOfCourse addedCategoryOfCourse = await _categoryOfCourseRepository.AddAsync(categoryOfCourse);

        return addedCategoryOfCourse;
    }

    public async Task<CategoryOfCourse> UpdateAsync(CategoryOfCourse categoryOfCourse)
    {
        CategoryOfCourse updatedCategoryOfCourse = await _categoryOfCourseRepository.UpdateAsync(categoryOfCourse);

        return updatedCategoryOfCourse;
    }

    public async Task<CategoryOfCourse> DeleteAsync(CategoryOfCourse categoryOfCourse, bool permanent = false)
    {
        CategoryOfCourse deletedCategoryOfCourse = await _categoryOfCourseRepository.DeleteAsync(categoryOfCourse);

        return deletedCategoryOfCourse;
    }
}
