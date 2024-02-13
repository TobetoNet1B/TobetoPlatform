using Application.Features.ModuleTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ModuleTypes.Rules;

public class ModuleTypeBusinessRules : BaseBusinessRules
{
    private readonly IModuleTypeRepository _moduleTypeRepository;

    public ModuleTypeBusinessRules(IModuleTypeRepository moduleTypeRepository)
    {
        _moduleTypeRepository = moduleTypeRepository;
    }

    public Task ModuleTypeShouldExistWhenSelected(ModuleType? moduleType)
    {
        if (moduleType == null)
            throw new BusinessException(ModuleTypesBusinessMessages.ModuleTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task ModuleTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ModuleType? moduleType = await _moduleTypeRepository.GetAsync(
            predicate: mt => mt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ModuleTypeShouldExistWhenSelected(moduleType);
    }
}