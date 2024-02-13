using Application.Features.CategoryOfCourses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CategoryOfCourses.Rules;

public class CategoryOfCourseBusinessRules : BaseBusinessRules
{
    private readonly ICategoryOfCourseRepository _categoryOfCourseRepository;

    public CategoryOfCourseBusinessRules(ICategoryOfCourseRepository categoryOfCourseRepository)
    {
        _categoryOfCourseRepository = categoryOfCourseRepository;
    }

    public Task CategoryOfCourseShouldExistWhenSelected(CategoryOfCourse? categoryOfCourse)
    {
        if (categoryOfCourse == null)
            throw new BusinessException(CategoryOfCoursesBusinessMessages.CategoryOfCourseNotExists);
        return Task.CompletedTask;
    }

    public async Task CategoryOfCourseIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CategoryOfCourse? categoryOfCourse = await _categoryOfCourseRepository.GetAsync(
            predicate: coc => coc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CategoryOfCourseShouldExistWhenSelected(categoryOfCourse);
    }
}