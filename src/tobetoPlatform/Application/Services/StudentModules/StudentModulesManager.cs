using Application.Features.StudentModules.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentModules;

public class StudentModulesManager : IStudentModulesService
{
    private readonly IStudentModuleRepository _studentModuleRepository;
    private readonly StudentModuleBusinessRules _studentModuleBusinessRules;

    public StudentModulesManager(IStudentModuleRepository studentModuleRepository, StudentModuleBusinessRules studentModuleBusinessRules)
    {
        _studentModuleRepository = studentModuleRepository;
        _studentModuleBusinessRules = studentModuleBusinessRules;
    }

    public async Task<StudentModule?> GetAsync(
        Expression<Func<StudentModule, bool>> predicate,
        Func<IQueryable<StudentModule>, IIncludableQueryable<StudentModule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentModule? studentModule = await _studentModuleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentModule;
    }

    public async Task<IPaginate<StudentModule>?> GetListAsync(
        Expression<Func<StudentModule, bool>>? predicate = null,
        Func<IQueryable<StudentModule>, IOrderedQueryable<StudentModule>>? orderBy = null,
        Func<IQueryable<StudentModule>, IIncludableQueryable<StudentModule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentModule> studentModuleList = await _studentModuleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentModuleList;
    }

    public async Task<StudentModule> AddAsync(StudentModule studentModule)
    {
        StudentModule addedStudentModule = await _studentModuleRepository.AddAsync(studentModule);

        return addedStudentModule;
    }

    public async Task<StudentModule> UpdateAsync(StudentModule studentModule)
    {
        StudentModule updatedStudentModule = await _studentModuleRepository.UpdateAsync(studentModule);

        return updatedStudentModule;
    }

    public async Task<StudentModule> DeleteAsync(StudentModule studentModule, bool permanent = false)
    {
        StudentModule deletedStudentModule = await _studentModuleRepository.DeleteAsync(studentModule);

        return deletedStudentModule;
    }
}
