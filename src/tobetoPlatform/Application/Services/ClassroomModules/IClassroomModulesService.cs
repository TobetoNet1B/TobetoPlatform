using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassroomModules;

public interface IClassroomModulesService
{
    Task<ClassroomModule?> GetAsync(
        Expression<Func<ClassroomModule, bool>> predicate,
        Func<IQueryable<ClassroomModule>, IIncludableQueryable<ClassroomModule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ClassroomModule>?> GetListAsync(
        Expression<Func<ClassroomModule, bool>>? predicate = null,
        Func<IQueryable<ClassroomModule>, IOrderedQueryable<ClassroomModule>>? orderBy = null,
        Func<IQueryable<ClassroomModule>, IIncludableQueryable<ClassroomModule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ClassroomModule> AddAsync(ClassroomModule classroomModule);
    Task<ClassroomModule> UpdateAsync(ClassroomModule classroomModule);
    Task<ClassroomModule> DeleteAsync(ClassroomModule classroomModule, bool permanent = false);
}
