using Application.Features.TobetoSendMessages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TobetoSendMessages;

public class TobetoSendMessagesManager : ITobetoSendMessagesService
{
    private readonly ITobetoSendMessageRepository _tobetoSendMessageRepository;
    private readonly TobetoSendMessageBusinessRules _tobetoSendMessageBusinessRules;

    public TobetoSendMessagesManager(ITobetoSendMessageRepository tobetoSendMessageRepository, TobetoSendMessageBusinessRules tobetoSendMessageBusinessRules)
    {
        _tobetoSendMessageRepository = tobetoSendMessageRepository;
        _tobetoSendMessageBusinessRules = tobetoSendMessageBusinessRules;
    }

    public async Task<TobetoSendMessage?> GetAsync(
        Expression<Func<TobetoSendMessage, bool>> predicate,
        Func<IQueryable<TobetoSendMessage>, IIncludableQueryable<TobetoSendMessage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TobetoSendMessage? tobetoSendMessage = await _tobetoSendMessageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return tobetoSendMessage;
    }

    public async Task<IPaginate<TobetoSendMessage>?> GetListAsync(
        Expression<Func<TobetoSendMessage, bool>>? predicate = null,
        Func<IQueryable<TobetoSendMessage>, IOrderedQueryable<TobetoSendMessage>>? orderBy = null,
        Func<IQueryable<TobetoSendMessage>, IIncludableQueryable<TobetoSendMessage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TobetoSendMessage> tobetoSendMessageList = await _tobetoSendMessageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return tobetoSendMessageList;
    }

    public async Task<TobetoSendMessage> AddAsync(TobetoSendMessage tobetoSendMessage)
    {
        TobetoSendMessage addedTobetoSendMessage = await _tobetoSendMessageRepository.AddAsync(tobetoSendMessage);

        return addedTobetoSendMessage;
    }

    public async Task<TobetoSendMessage> UpdateAsync(TobetoSendMessage tobetoSendMessage)
    {
        TobetoSendMessage updatedTobetoSendMessage = await _tobetoSendMessageRepository.UpdateAsync(tobetoSendMessage);

        return updatedTobetoSendMessage;
    }

    public async Task<TobetoSendMessage> DeleteAsync(TobetoSendMessage tobetoSendMessage, bool permanent = false)
    {
        TobetoSendMessage deletedTobetoSendMessage = await _tobetoSendMessageRepository.DeleteAsync(tobetoSendMessage);

        return deletedTobetoSendMessage;
    }
}
