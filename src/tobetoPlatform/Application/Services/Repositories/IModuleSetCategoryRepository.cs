using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IModuleSetCategoryRepository : IAsyncRepository<ModuleSetCategory, Guid>, IRepository<ModuleSetCategory, Guid>
{
}