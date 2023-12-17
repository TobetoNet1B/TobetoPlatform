using Application.Features.StudentClassrooms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentClassrooms.Rules;

public class StudentClassroomBusinessRules : BaseBusinessRules
{
    private readonly IStudentClassroomRepository _studentClassroomRepository;

    public StudentClassroomBusinessRules(IStudentClassroomRepository studentClassroomRepository)
    {
        _studentClassroomRepository = studentClassroomRepository;
    }

    public Task StudentClassroomShouldExistWhenSelected(StudentClassroom? studentClassroom)
    {
        if (studentClassroom == null)
            throw new BusinessException(StudentClassroomsBusinessMessages.StudentClassroomNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentClassroomIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentClassroom? studentClassroom = await _studentClassroomRepository.GetAsync(
            predicate: sc => sc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentClassroomShouldExistWhenSelected(studentClassroom);
    }
}