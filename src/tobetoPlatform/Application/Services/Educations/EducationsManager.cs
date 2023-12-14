using Application.Features.Educations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Educations;

public class EducationsManager : IEducationsService
{
    private readonly IEducationRepository _educationRepository;
    private readonly EducationBusinessRules _educationBusinessRules;

    public EducationsManager(IEducationRepository educationRepository, EducationBusinessRules educationBusinessRules)
    {
        _educationRepository = educationRepository;
        _educationBusinessRules = educationBusinessRules;
    }

    public async Task<Education?> GetAsync(
        Expression<Func<Education, bool>> predicate,
        Func<IQueryable<Education>, IIncludableQueryable<Education, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Education? education = await _educationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return education;
    }

    public async Task<IPaginate<Education>?> GetListAsync(
        Expression<Func<Education, bool>>? predicate = null,
        Func<IQueryable<Education>, IOrderedQueryable<Education>>? orderBy = null,
        Func<IQueryable<Education>, IIncludableQueryable<Education, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Education> educationList = await _educationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return educationList;
    }

    public async Task<Education> AddAsync(Education education)
    {
        Education addedEducation = await _educationRepository.AddAsync(education);

        return addedEducation;
    }

    public async Task<Education> UpdateAsync(Education education)
    {
        Education updatedEducation = await _educationRepository.UpdateAsync(education);

        return updatedEducation;
    }

    public async Task<Education> DeleteAsync(Education education, bool permanent = false)
    {
        Education deletedEducation = await _educationRepository.DeleteAsync(education);

        return deletedEducation;
    }
}
