using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IModuleSetRepository : IAsyncRepository<ModuleSet, Guid>, IRepository<ModuleSet, Guid>
{
}