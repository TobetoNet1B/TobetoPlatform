using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TobetoContacts;

public interface ITobetoContactsService
{
    Task<TobetoContact?> GetAsync(
        Expression<Func<TobetoContact, bool>> predicate,
        Func<IQueryable<TobetoContact>, IIncludableQueryable<TobetoContact, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TobetoContact>?> GetListAsync(
        Expression<Func<TobetoContact, bool>>? predicate = null,
        Func<IQueryable<TobetoContact>, IOrderedQueryable<TobetoContact>>? orderBy = null,
        Func<IQueryable<TobetoContact>, IIncludableQueryable<TobetoContact, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TobetoContact> AddAsync(TobetoContact tobetoContact);
    Task<TobetoContact> UpdateAsync(TobetoContact tobetoContact);
    Task<TobetoContact> DeleteAsync(TobetoContact tobetoContact, bool permanent = false);
}
