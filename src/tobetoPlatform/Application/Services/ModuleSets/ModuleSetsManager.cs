using Application.Features.ModuleSets.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ModuleSets;

public class ModuleSetsManager : IModuleSetsService
{
    private readonly IModuleSetRepository _moduleSetRepository;
    private readonly ModuleSetBusinessRules _moduleSetBusinessRules;

    public ModuleSetsManager(IModuleSetRepository moduleSetRepository, ModuleSetBusinessRules moduleSetBusinessRules)
    {
        _moduleSetRepository = moduleSetRepository;
        _moduleSetBusinessRules = moduleSetBusinessRules;
    }

    public async Task<ModuleSet?> GetAsync(
        Expression<Func<ModuleSet, bool>> predicate,
        Func<IQueryable<ModuleSet>, IIncludableQueryable<ModuleSet, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ModuleSet? moduleSet = await _moduleSetRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return moduleSet;
    }

    public async Task<IPaginate<ModuleSet>?> GetListAsync(
        Expression<Func<ModuleSet, bool>>? predicate = null,
        Func<IQueryable<ModuleSet>, IOrderedQueryable<ModuleSet>>? orderBy = null,
        Func<IQueryable<ModuleSet>, IIncludableQueryable<ModuleSet, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ModuleSet> moduleSetList = await _moduleSetRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return moduleSetList;
    }

    public async Task<ModuleSet> AddAsync(ModuleSet moduleSet)
    {
        ModuleSet addedModuleSet = await _moduleSetRepository.AddAsync(moduleSet);

        return addedModuleSet;
    }

    public async Task<ModuleSet> UpdateAsync(ModuleSet moduleSet)
    {
        ModuleSet updatedModuleSet = await _moduleSetRepository.UpdateAsync(moduleSet);

        return updatedModuleSet;
    }

    public async Task<ModuleSet> DeleteAsync(ModuleSet moduleSet, bool permanent = false)
    {
        ModuleSet deletedModuleSet = await _moduleSetRepository.DeleteAsync(moduleSet);

        return deletedModuleSet;
    }
}
