using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentModules;

public interface IStudentModulesService
{
    Task<StudentModule?> GetAsync(
        Expression<Func<StudentModule, bool>> predicate,
        Func<IQueryable<StudentModule>, IIncludableQueryable<StudentModule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentModule>?> GetListAsync(
        Expression<Func<StudentModule, bool>>? predicate = null,
        Func<IQueryable<StudentModule>, IOrderedQueryable<StudentModule>>? orderBy = null,
        Func<IQueryable<StudentModule>, IIncludableQueryable<StudentModule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentModule> AddAsync(StudentModule studentModule);
    Task<StudentModule> UpdateAsync(StudentModule studentModule);
    Task<StudentModule> DeleteAsync(StudentModule studentModule, bool permanent = false);
}
