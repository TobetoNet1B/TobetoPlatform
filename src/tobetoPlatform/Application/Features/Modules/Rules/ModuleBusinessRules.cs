using Application.Features.Modules.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Modules.Rules;

public class ModuleBusinessRules : BaseBusinessRules
{
    private readonly IModuleRepository _moduleRepository;

    public ModuleBusinessRules(IModuleRepository moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public Task ModuleShouldExistWhenSelected(Module? module)
    {
        if (module == null)
            throw new BusinessException(ModulesBusinessMessages.ModuleNotExists);
        return Task.CompletedTask;
    }

    public async Task ModuleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Module? module = await _moduleRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ModuleShouldExistWhenSelected(module);
    }
}