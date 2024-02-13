using Application.Features.Abilities.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Abilities.Rules;

public class AbilityBusinessRules : BaseBusinessRules
{
    private readonly IAbilityRepository _abilityRepository;

    public AbilityBusinessRules(IAbilityRepository abilityRepository)
    {
        _abilityRepository = abilityRepository;
    }

    public Task AbilityShouldExistWhenSelected(Ability? ability)
    {
        if (ability == null)
            throw new BusinessException(AbilitiesBusinessMessages.AbilityNotExists);
        return Task.CompletedTask;
    }

    public async Task AbilityIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Ability? ability = await _abilityRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AbilityShouldExistWhenSelected(ability);
    }

    public async Task AbilityNameCanNotBeDuplicationWhenInserted(Guid id, Ability ability)
    {
        IPaginate<Ability> result = await _abilityRepository.GetListAsync(s => s.StudentId == id);
        if (result.Items.Any(c => c.Name == ability.Name))
            throw new Exception(AbilitiesBusinessMessages.AbilityNameExists);
    }
}