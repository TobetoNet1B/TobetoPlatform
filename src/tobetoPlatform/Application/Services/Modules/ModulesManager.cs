using Application.Features.Modules.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Modules;

public class ModulesManager : IModulesService
{
    private readonly IModuleRepository _moduleRepository;
    private readonly ModuleBusinessRules _moduleBusinessRules;

    public ModulesManager(IModuleRepository moduleRepository, ModuleBusinessRules moduleBusinessRules)
    {
        _moduleRepository = moduleRepository;
        _moduleBusinessRules = moduleBusinessRules;
    }

    public async Task<Module?> GetAsync(
        Expression<Func<Module, bool>> predicate,
        Func<IQueryable<Module>, IIncludableQueryable<Module, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Module? module = await _moduleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return module;
    }

    public async Task<IPaginate<Module>?> GetListAsync(
        Expression<Func<Module, bool>>? predicate = null,
        Func<IQueryable<Module>, IOrderedQueryable<Module>>? orderBy = null,
        Func<IQueryable<Module>, IIncludableQueryable<Module, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Module> moduleList = await _moduleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return moduleList;
    }

    public async Task<Module> AddAsync(Module module)
    {
        Module addedModule = await _moduleRepository.AddAsync(module);

        return addedModule;
    }

    public async Task<Module> UpdateAsync(Module module)
    {
        Module updatedModule = await _moduleRepository.UpdateAsync(module);

        return updatedModule;
    }

    public async Task<Module> DeleteAsync(Module module, bool permanent = false)
    {
        Module deletedModule = await _moduleRepository.DeleteAsync(module);

        return deletedModule;
    }
}
