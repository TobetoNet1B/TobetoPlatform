using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentForeignLanguages;

public interface IStudentForeignLanguagesService
{
    Task<StudentForeignLanguage?> GetAsync(
        Expression<Func<StudentForeignLanguage, bool>> predicate,
        Func<IQueryable<StudentForeignLanguage>, IIncludableQueryable<StudentForeignLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentForeignLanguage>?> GetListAsync(
        Expression<Func<StudentForeignLanguage, bool>>? predicate = null,
        Func<IQueryable<StudentForeignLanguage>, IOrderedQueryable<StudentForeignLanguage>>? orderBy = null,
        Func<IQueryable<StudentForeignLanguage>, IIncludableQueryable<StudentForeignLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentForeignLanguage> AddAsync(StudentForeignLanguage studentForeignLanguage);
    Task<StudentForeignLanguage> UpdateAsync(StudentForeignLanguage studentForeignLanguage);
    Task<StudentForeignLanguage> DeleteAsync(StudentForeignLanguage studentForeignLanguage, bool permanent = false);
}
