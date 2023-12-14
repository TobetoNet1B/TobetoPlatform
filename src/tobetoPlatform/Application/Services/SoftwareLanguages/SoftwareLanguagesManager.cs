using Application.Features.SoftwareLanguages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SoftwareLanguages;

public class SoftwareLanguagesManager : ISoftwareLanguagesService
{
    private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
    private readonly SoftwareLanguageBusinessRules _softwareLanguageBusinessRules;

    public SoftwareLanguagesManager(ISoftwareLanguageRepository softwareLanguageRepository, SoftwareLanguageBusinessRules softwareLanguageBusinessRules)
    {
        _softwareLanguageRepository = softwareLanguageRepository;
        _softwareLanguageBusinessRules = softwareLanguageBusinessRules;
    }

    public async Task<SoftwareLanguage?> GetAsync(
        Expression<Func<SoftwareLanguage, bool>> predicate,
        Func<IQueryable<SoftwareLanguage>, IIncludableQueryable<SoftwareLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SoftwareLanguage? softwareLanguage = await _softwareLanguageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return softwareLanguage;
    }

    public async Task<IPaginate<SoftwareLanguage>?> GetListAsync(
        Expression<Func<SoftwareLanguage, bool>>? predicate = null,
        Func<IQueryable<SoftwareLanguage>, IOrderedQueryable<SoftwareLanguage>>? orderBy = null,
        Func<IQueryable<SoftwareLanguage>, IIncludableQueryable<SoftwareLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SoftwareLanguage> softwareLanguageList = await _softwareLanguageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return softwareLanguageList;
    }

    public async Task<SoftwareLanguage> AddAsync(SoftwareLanguage softwareLanguage)
    {
        SoftwareLanguage addedSoftwareLanguage = await _softwareLanguageRepository.AddAsync(softwareLanguage);

        return addedSoftwareLanguage;
    }

    public async Task<SoftwareLanguage> UpdateAsync(SoftwareLanguage softwareLanguage)
    {
        SoftwareLanguage updatedSoftwareLanguage = await _softwareLanguageRepository.UpdateAsync(softwareLanguage);

        return updatedSoftwareLanguage;
    }

    public async Task<SoftwareLanguage> DeleteAsync(SoftwareLanguage softwareLanguage, bool permanent = false)
    {
        SoftwareLanguage deletedSoftwareLanguage = await _softwareLanguageRepository.DeleteAsync(softwareLanguage);

        return deletedSoftwareLanguage;
    }
}
