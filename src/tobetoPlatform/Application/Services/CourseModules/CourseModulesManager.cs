using Application.Features.CourseModules.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseModules;

public class CourseModulesManager : ICourseModulesService
{
    private readonly ICourseModuleRepository _courseModuleRepository;
    private readonly CourseModuleBusinessRules _courseModuleBusinessRules;

    public CourseModulesManager(ICourseModuleRepository courseModuleRepository, CourseModuleBusinessRules courseModuleBusinessRules)
    {
        _courseModuleRepository = courseModuleRepository;
        _courseModuleBusinessRules = courseModuleBusinessRules;
    }

    public async Task<CourseModule?> GetAsync(
        Expression<Func<CourseModule, bool>> predicate,
        Func<IQueryable<CourseModule>, IIncludableQueryable<CourseModule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CourseModule? courseModule = await _courseModuleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return courseModule;
    }

    public async Task<IPaginate<CourseModule>?> GetListAsync(
        Expression<Func<CourseModule, bool>>? predicate = null,
        Func<IQueryable<CourseModule>, IOrderedQueryable<CourseModule>>? orderBy = null,
        Func<IQueryable<CourseModule>, IIncludableQueryable<CourseModule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CourseModule> courseModuleList = await _courseModuleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseModuleList;
    }

    public async Task<CourseModule> AddAsync(CourseModule courseModule)
    {
        CourseModule addedCourseModule = await _courseModuleRepository.AddAsync(courseModule);

        return addedCourseModule;
    }

    public async Task<CourseModule> UpdateAsync(CourseModule courseModule)
    {
        CourseModule updatedCourseModule = await _courseModuleRepository.UpdateAsync(courseModule);

        return updatedCourseModule;
    }

    public async Task<CourseModule> DeleteAsync(CourseModule courseModule, bool permanent = false)
    {
        CourseModule deletedCourseModule = await _courseModuleRepository.DeleteAsync(courseModule);

        return deletedCourseModule;
    }
}
