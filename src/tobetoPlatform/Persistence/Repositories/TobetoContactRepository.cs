using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TobetoContactRepository : EfRepositoryBase<TobetoContact, Guid, BaseDbContext>, ITobetoContactRepository
{
    public TobetoContactRepository(BaseDbContext context) : base(context)
    {
    }
}