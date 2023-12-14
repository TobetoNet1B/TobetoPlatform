using Application.Features.StudentModules.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentModules.Rules;

public class StudentModuleBusinessRules : BaseBusinessRules
{
    private readonly IStudentModuleRepository _studentModuleRepository;

    public StudentModuleBusinessRules(IStudentModuleRepository studentModuleRepository)
    {
        _studentModuleRepository = studentModuleRepository;
    }

    public Task StudentModuleShouldExistWhenSelected(StudentModule? studentModule)
    {
        if (studentModule == null)
            throw new BusinessException(StudentModulesBusinessMessages.StudentModuleNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentModuleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentModule? studentModule = await _studentModuleRepository.GetAsync(
            predicate: sm => sm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentModuleShouldExistWhenSelected(studentModule);
    }
}