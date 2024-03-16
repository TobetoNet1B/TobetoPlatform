using Application.Features.TobetoContacts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.TobetoContacts.Rules;

public class TobetoContactBusinessRules : BaseBusinessRules
{
    private readonly ITobetoContactRepository _tobetoContactRepository;

    public TobetoContactBusinessRules(ITobetoContactRepository tobetoContactRepository)
    {
        _tobetoContactRepository = tobetoContactRepository;
    }

    public Task TobetoContactShouldExistWhenSelected(TobetoContact? tobetoContact)
    {
        if (tobetoContact == null)
            throw new BusinessException(TobetoContactsBusinessMessages.TobetoContactNotExists);
        return Task.CompletedTask;
    }

    public async Task TobetoContactIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TobetoContact? tobetoContact = await _tobetoContactRepository.GetAsync(
            predicate: tc => tc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TobetoContactShouldExistWhenSelected(tobetoContact);
    }
}