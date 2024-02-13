using Application.Features.ClassroomModules.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassroomModules;

public class ClassroomModulesManager : IClassroomModulesService
{
    private readonly IClassroomModuleRepository _classroomModuleRepository;
    private readonly ClassroomModuleBusinessRules _classroomModuleBusinessRules;

    public ClassroomModulesManager(IClassroomModuleRepository classroomModuleRepository, ClassroomModuleBusinessRules classroomModuleBusinessRules)
    {
        _classroomModuleRepository = classroomModuleRepository;
        _classroomModuleBusinessRules = classroomModuleBusinessRules;
    }

    public async Task<ClassroomModule?> GetAsync(
        Expression<Func<ClassroomModule, bool>> predicate,
        Func<IQueryable<ClassroomModule>, IIncludableQueryable<ClassroomModule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ClassroomModule? classroomModule = await _classroomModuleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return classroomModule;
    }

    public async Task<IPaginate<ClassroomModule>?> GetListAsync(
        Expression<Func<ClassroomModule, bool>>? predicate = null,
        Func<IQueryable<ClassroomModule>, IOrderedQueryable<ClassroomModule>>? orderBy = null,
        Func<IQueryable<ClassroomModule>, IIncludableQueryable<ClassroomModule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ClassroomModule> classroomModuleList = await _classroomModuleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return classroomModuleList;
    }

    public async Task<ClassroomModule> AddAsync(ClassroomModule classroomModule)
    {
        ClassroomModule addedClassroomModule = await _classroomModuleRepository.AddAsync(classroomModule);

        return addedClassroomModule;
    }

    public async Task<ClassroomModule> UpdateAsync(ClassroomModule classroomModule)
    {
        ClassroomModule updatedClassroomModule = await _classroomModuleRepository.UpdateAsync(classroomModule);

        return updatedClassroomModule;
    }

    public async Task<ClassroomModule> DeleteAsync(ClassroomModule classroomModule, bool permanent = false)
    {
        ClassroomModule deletedClassroomModule = await _classroomModuleRepository.DeleteAsync(classroomModule);

        return deletedClassroomModule;
    }
}
