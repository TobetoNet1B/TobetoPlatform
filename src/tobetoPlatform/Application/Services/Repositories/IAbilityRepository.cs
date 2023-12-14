using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAbilityRepository : IAsyncRepository<Ability, Guid>, IRepository<Ability, Guid>
{
}