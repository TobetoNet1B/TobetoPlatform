using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IModuleTypeRepository : IAsyncRepository<ModuleType, Guid>, IRepository<ModuleType, Guid>
{
}