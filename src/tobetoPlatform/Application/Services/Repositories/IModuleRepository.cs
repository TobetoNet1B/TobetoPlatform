using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IModuleRepository : IAsyncRepository<Module, Guid>, IRepository<Module, Guid>
{
}