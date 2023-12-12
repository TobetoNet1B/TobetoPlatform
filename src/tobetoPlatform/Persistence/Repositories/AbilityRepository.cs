using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AbilityRepository : EfRepositoryBase<Ability, Guid, BaseDbContext>, IAbilityRepository
{
    public AbilityRepository(BaseDbContext context) : base(context)
    {
    }
}