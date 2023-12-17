using Application.Features.ModuleSets.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ModuleSets.Rules;

public class ModuleSetBusinessRules : BaseBusinessRules
{
    private readonly IModuleSetRepository _moduleSetRepository;

    public ModuleSetBusinessRules(IModuleSetRepository moduleSetRepository)
    {
        _moduleSetRepository = moduleSetRepository;
    }

    public Task ModuleSetShouldExistWhenSelected(ModuleSet? moduleSet)
    {
        if (moduleSet == null)
            throw new BusinessException(ModuleSetsBusinessMessages.ModuleSetNotExists);
        return Task.CompletedTask;
    }

    public async Task ModuleSetIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ModuleSet? moduleSet = await _moduleSetRepository.GetAsync(
            predicate: ms => ms.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ModuleSetShouldExistWhenSelected(moduleSet);
    }
}