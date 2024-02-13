using Application.Features.ClassroomModules.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ClassroomModules.Rules;

public class ClassroomModuleBusinessRules : BaseBusinessRules
{
    private readonly IClassroomModuleRepository _classroomModuleRepository;

    public ClassroomModuleBusinessRules(IClassroomModuleRepository classroomModuleRepository)
    {
        _classroomModuleRepository = classroomModuleRepository;
    }

    public Task ClassroomModuleShouldExistWhenSelected(ClassroomModule? classroomModule)
    {
        if (classroomModule == null)
            throw new BusinessException(ClassroomModulesBusinessMessages.ClassroomModuleNotExists);
        return Task.CompletedTask;
    }

    public async Task ClassroomModuleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ClassroomModule? classroomModule = await _classroomModuleRepository.GetAsync(
            predicate: cm => cm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ClassroomModuleShouldExistWhenSelected(classroomModule);
    }
}