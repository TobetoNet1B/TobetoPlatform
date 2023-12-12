using Application.Features.Courses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Courses.Rules;

public class CourseBusinessRules : BaseBusinessRules
{
    private readonly ICourseRepository _courseRepository;

    public CourseBusinessRules(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public Task CourseShouldExistWhenSelected(Course? course)
    {
        if (course == null)
            throw new BusinessException(CoursesBusinessMessages.CourseNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Course? course = await _courseRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseShouldExistWhenSelected(course);
    }
    public async Task CourseNameCanNotBeDuplicationWhenInserted(string name)
    {
        IPaginate<Course> result = await _courseRepository.GetListAsync(c => c.Name == name);
        if (result.Items.Any())
            throw new Exception("Course name exitst");
    }
}