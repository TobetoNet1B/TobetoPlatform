using Application.Features.CourseStudents.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseStudents;

public class CourseStudentsManager : ICourseStudentsService
{
    private readonly ICourseStudentRepository _courseStudentRepository;
    private readonly CourseStudentBusinessRules _courseStudentBusinessRules;

    public CourseStudentsManager(ICourseStudentRepository courseStudentRepository, CourseStudentBusinessRules courseStudentBusinessRules)
    {
        _courseStudentRepository = courseStudentRepository;
        _courseStudentBusinessRules = courseStudentBusinessRules;
    }

    public async Task<CourseStudent?> GetAsync(
        Expression<Func<CourseStudent, bool>> predicate,
        Func<IQueryable<CourseStudent>, IIncludableQueryable<CourseStudent, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CourseStudent? courseStudent = await _courseStudentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return courseStudent;
    }

    public async Task<IPaginate<CourseStudent>?> GetListAsync(
        Expression<Func<CourseStudent, bool>>? predicate = null,
        Func<IQueryable<CourseStudent>, IOrderedQueryable<CourseStudent>>? orderBy = null,
        Func<IQueryable<CourseStudent>, IIncludableQueryable<CourseStudent, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CourseStudent> courseStudentList = await _courseStudentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseStudentList;
    }

    public async Task<CourseStudent> AddAsync(CourseStudent courseStudent)
    {
        CourseStudent addedCourseStudent = await _courseStudentRepository.AddAsync(courseStudent);

        return addedCourseStudent;
    }

    public async Task<CourseStudent> UpdateAsync(CourseStudent courseStudent)
    {
        CourseStudent updatedCourseStudent = await _courseStudentRepository.UpdateAsync(courseStudent);

        return updatedCourseStudent;
    }

    public async Task<CourseStudent> DeleteAsync(CourseStudent courseStudent, bool permanent = false)
    {
        CourseStudent deletedCourseStudent = await _courseStudentRepository.DeleteAsync(courseStudent);

        return deletedCourseStudent;
    }
}
