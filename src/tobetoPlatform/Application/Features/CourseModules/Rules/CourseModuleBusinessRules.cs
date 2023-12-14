using Application.Features.CourseModules.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CourseModules.Rules;

public class CourseModuleBusinessRules : BaseBusinessRules
{
    private readonly ICourseModuleRepository _courseModuleRepository;

    public CourseModuleBusinessRules(ICourseModuleRepository courseModuleRepository)
    {
        _courseModuleRepository = courseModuleRepository;
    }

    public Task CourseModuleShouldExistWhenSelected(CourseModule? courseModule)
    {
        if (courseModule == null)
            throw new BusinessException(CourseModulesBusinessMessages.CourseModuleNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseModuleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CourseModule? courseModule = await _courseModuleRepository.GetAsync(
            predicate: cm => cm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseModuleShouldExistWhenSelected(courseModule);
    }
}