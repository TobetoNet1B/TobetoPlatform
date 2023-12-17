using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentClassrooms;

public interface IStudentClassroomsService
{
    Task<StudentClassroom?> GetAsync(
        Expression<Func<StudentClassroom, bool>> predicate,
        Func<IQueryable<StudentClassroom>, IIncludableQueryable<StudentClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentClassroom>?> GetListAsync(
        Expression<Func<StudentClassroom, bool>>? predicate = null,
        Func<IQueryable<StudentClassroom>, IOrderedQueryable<StudentClassroom>>? orderBy = null,
        Func<IQueryable<StudentClassroom>, IIncludableQueryable<StudentClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentClassroom> AddAsync(StudentClassroom studentClassroom);
    Task<StudentClassroom> UpdateAsync(StudentClassroom studentClassroom);
    Task<StudentClassroom> DeleteAsync(StudentClassroom studentClassroom, bool permanent = false);
}
