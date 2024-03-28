using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TobetoSendMessages;

public interface ITobetoSendMessagesService
{
    Task<TobetoSendMessage?> GetAsync(
        Expression<Func<TobetoSendMessage, bool>> predicate,
        Func<IQueryable<TobetoSendMessage>, IIncludableQueryable<TobetoSendMessage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TobetoSendMessage>?> GetListAsync(
        Expression<Func<TobetoSendMessage, bool>>? predicate = null,
        Func<IQueryable<TobetoSendMessage>, IOrderedQueryable<TobetoSendMessage>>? orderBy = null,
        Func<IQueryable<TobetoSendMessage>, IIncludableQueryable<TobetoSendMessage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TobetoSendMessage> AddAsync(TobetoSendMessage tobetoSendMessage);
    Task<TobetoSendMessage> UpdateAsync(TobetoSendMessage tobetoSendMessage);
    Task<TobetoSendMessage> DeleteAsync(TobetoSendMessage tobetoSendMessage, bool permanent = false);
}
