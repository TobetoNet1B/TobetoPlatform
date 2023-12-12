using Application.Features.CourseStudents.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CourseStudents.Rules;

public class CourseStudentBusinessRules : BaseBusinessRules
{
    private readonly ICourseStudentRepository _courseStudentRepository;

    public CourseStudentBusinessRules(ICourseStudentRepository courseStudentRepository)
    {
        _courseStudentRepository = courseStudentRepository;
    }

    public Task CourseStudentShouldExistWhenSelected(CourseStudent? courseStudent)
    {
        if (courseStudent == null)
            throw new BusinessException(CourseStudentsBusinessMessages.CourseStudentNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseStudentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CourseStudent? courseStudent = await _courseStudentRepository.GetAsync(
            predicate: cs => cs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseStudentShouldExistWhenSelected(courseStudent);
    }
}