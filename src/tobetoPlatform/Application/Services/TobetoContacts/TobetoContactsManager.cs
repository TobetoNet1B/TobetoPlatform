using Application.Features.TobetoContacts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TobetoContacts;

public class TobetoContactsManager : ITobetoContactsService
{
    private readonly ITobetoContactRepository _tobetoContactRepository;
    private readonly TobetoContactBusinessRules _tobetoContactBusinessRules;

    public TobetoContactsManager(ITobetoContactRepository tobetoContactRepository, TobetoContactBusinessRules tobetoContactBusinessRules)
    {
        _tobetoContactRepository = tobetoContactRepository;
        _tobetoContactBusinessRules = tobetoContactBusinessRules;
    }

    public async Task<TobetoContact?> GetAsync(
        Expression<Func<TobetoContact, bool>> predicate,
        Func<IQueryable<TobetoContact>, IIncludableQueryable<TobetoContact, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TobetoContact? tobetoContact = await _tobetoContactRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return tobetoContact;
    }

    public async Task<IPaginate<TobetoContact>?> GetListAsync(
        Expression<Func<TobetoContact, bool>>? predicate = null,
        Func<IQueryable<TobetoContact>, IOrderedQueryable<TobetoContact>>? orderBy = null,
        Func<IQueryable<TobetoContact>, IIncludableQueryable<TobetoContact, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TobetoContact> tobetoContactList = await _tobetoContactRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return tobetoContactList;
    }

    public async Task<TobetoContact> AddAsync(TobetoContact tobetoContact)
    {
        TobetoContact addedTobetoContact = await _tobetoContactRepository.AddAsync(tobetoContact);

        return addedTobetoContact;
    }

    public async Task<TobetoContact> UpdateAsync(TobetoContact tobetoContact)
    {
        TobetoContact updatedTobetoContact = await _tobetoContactRepository.UpdateAsync(tobetoContact);

        return updatedTobetoContact;
    }

    public async Task<TobetoContact> DeleteAsync(TobetoContact tobetoContact, bool permanent = false)
    {
        TobetoContact deletedTobetoContact = await _tobetoContactRepository.DeleteAsync(tobetoContact);

        return deletedTobetoContact;
    }
}
