using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SoftwareLanguages;

public interface ISoftwareLanguagesService
{
    Task<SoftwareLanguage?> GetAsync(
        Expression<Func<SoftwareLanguage, bool>> predicate,
        Func<IQueryable<SoftwareLanguage>, IIncludableQueryable<SoftwareLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SoftwareLanguage>?> GetListAsync(
        Expression<Func<SoftwareLanguage, bool>>? predicate = null,
        Func<IQueryable<SoftwareLanguage>, IOrderedQueryable<SoftwareLanguage>>? orderBy = null,
        Func<IQueryable<SoftwareLanguage>, IIncludableQueryable<SoftwareLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SoftwareLanguage> AddAsync(SoftwareLanguage softwareLanguage);
    Task<SoftwareLanguage> UpdateAsync(SoftwareLanguage softwareLanguage);
    Task<SoftwareLanguage> DeleteAsync(SoftwareLanguage softwareLanguage, bool permanent = false);
}
