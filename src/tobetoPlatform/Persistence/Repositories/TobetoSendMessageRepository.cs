using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TobetoSendMessageRepository : EfRepositoryBase<TobetoSendMessage, Guid, BaseDbContext>, ITobetoSendMessageRepository
{
    public TobetoSendMessageRepository(BaseDbContext context) : base(context)
    {
    }
}