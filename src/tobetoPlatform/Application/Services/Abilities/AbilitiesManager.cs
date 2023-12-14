using Application.Features.Abilities.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Abilities;

public class AbilitiesManager : IAbilitiesService
{
    private readonly IAbilityRepository _abilityRepository;
    private readonly AbilityBusinessRules _abilityBusinessRules;

    public AbilitiesManager(IAbilityRepository abilityRepository, AbilityBusinessRules abilityBusinessRules)
    {
        _abilityRepository = abilityRepository;
        _abilityBusinessRules = abilityBusinessRules;
    }

    public async Task<Ability?> GetAsync(
        Expression<Func<Ability, bool>> predicate,
        Func<IQueryable<Ability>, IIncludableQueryable<Ability, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Ability? ability = await _abilityRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ability;
    }

    public async Task<IPaginate<Ability>?> GetListAsync(
        Expression<Func<Ability, bool>>? predicate = null,
        Func<IQueryable<Ability>, IOrderedQueryable<Ability>>? orderBy = null,
        Func<IQueryable<Ability>, IIncludableQueryable<Ability, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Ability> abilityList = await _abilityRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return abilityList;
    }

    public async Task<Ability> AddAsync(Ability ability)
    {
        Ability addedAbility = await _abilityRepository.AddAsync(ability);

        return addedAbility;
    }

    public async Task<Ability> UpdateAsync(Ability ability)
    {
        Ability updatedAbility = await _abilityRepository.UpdateAsync(ability);

        return updatedAbility;
    }

    public async Task<Ability> DeleteAsync(Ability ability, bool permanent = false)
    {
        Ability deletedAbility = await _abilityRepository.DeleteAsync(ability);

        return deletedAbility;
    }
}
