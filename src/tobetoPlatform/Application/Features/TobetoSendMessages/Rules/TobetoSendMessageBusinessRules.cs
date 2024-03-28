using Application.Features.TobetoSendMessages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.TobetoSendMessages.Rules;

public class TobetoSendMessageBusinessRules : BaseBusinessRules
{
    private readonly ITobetoSendMessageRepository _tobetoSendMessageRepository;

    public TobetoSendMessageBusinessRules(ITobetoSendMessageRepository tobetoSendMessageRepository)
    {
        _tobetoSendMessageRepository = tobetoSendMessageRepository;
    }

    public Task TobetoSendMessageShouldExistWhenSelected(TobetoSendMessage? tobetoSendMessage)
    {
        if (tobetoSendMessage == null)
            throw new BusinessException(TobetoSendMessagesBusinessMessages.TobetoSendMessageNotExists);
        return Task.CompletedTask;
    }

    public async Task TobetoSendMessageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TobetoSendMessage? tobetoSendMessage = await _tobetoSendMessageRepository.GetAsync(
            predicate: tsm => tsm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TobetoSendMessageShouldExistWhenSelected(tobetoSendMessage);
    }
}