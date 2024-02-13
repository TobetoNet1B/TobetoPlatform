using Application.Features.ModuleTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ModuleTypes;

public class ModuleTypesManager : IModuleTypesService
{
    private readonly IModuleTypeRepository _moduleTypeRepository;
    private readonly ModuleTypeBusinessRules _moduleTypeBusinessRules;

    public ModuleTypesManager(IModuleTypeRepository moduleTypeRepository, ModuleTypeBusinessRules moduleTypeBusinessRules)
    {
        _moduleTypeRepository = moduleTypeRepository;
        _moduleTypeBusinessRules = moduleTypeBusinessRules;
    }

    public async Task<ModuleType?> GetAsync(
        Expression<Func<ModuleType, bool>> predicate,
        Func<IQueryable<ModuleType>, IIncludableQueryable<ModuleType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ModuleType? moduleType = await _moduleTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return moduleType;
    }

    public async Task<IPaginate<ModuleType>?> GetListAsync(
        Expression<Func<ModuleType, bool>>? predicate = null,
        Func<IQueryable<ModuleType>, IOrderedQueryable<ModuleType>>? orderBy = null,
        Func<IQueryable<ModuleType>, IIncludableQueryable<ModuleType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ModuleType> moduleTypeList = await _moduleTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return moduleTypeList;
    }

    public async Task<ModuleType> AddAsync(ModuleType moduleType)
    {
        ModuleType addedModuleType = await _moduleTypeRepository.AddAsync(moduleType);

        return addedModuleType;
    }

    public async Task<ModuleType> UpdateAsync(ModuleType moduleType)
    {
        ModuleType updatedModuleType = await _moduleTypeRepository.UpdateAsync(moduleType);

        return updatedModuleType;
    }

    public async Task<ModuleType> DeleteAsync(ModuleType moduleType, bool permanent = false)
    {
        ModuleType deletedModuleType = await _moduleTypeRepository.DeleteAsync(moduleType);

        return deletedModuleType;
    }
}
