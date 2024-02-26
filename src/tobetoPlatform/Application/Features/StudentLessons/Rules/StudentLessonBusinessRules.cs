using Application.Features.StudentLessons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentLessons.Rules;

public class StudentLessonBusinessRules : BaseBusinessRules
{
    private readonly IStudentLessonRepository _studentLessonRepository;

    public StudentLessonBusinessRules(IStudentLessonRepository studentLessonRepository)
    {
        _studentLessonRepository = studentLessonRepository;
    }

    public Task StudentLessonShouldExistWhenSelected(StudentLesson? studentLesson)
    {
        if (studentLesson == null)
            throw new BusinessException(StudentLessonsBusinessMessages.StudentLessonNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentLessonIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentLesson? studentLesson = await _studentLessonRepository.GetAsync(
            predicate: sl => sl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentLessonShouldExistWhenSelected(studentLesson);
    }
}