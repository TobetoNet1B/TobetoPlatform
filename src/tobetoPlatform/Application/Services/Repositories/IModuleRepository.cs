using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IModuleRepository : IAsyncRepository<ModuleSet, Guid>, IRepository<ModuleSet, Guid>
{
}