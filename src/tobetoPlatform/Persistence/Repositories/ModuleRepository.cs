using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModuleRepository : EfRepositoryBase<Module, Guid, BaseDbContext>, IModuleRepository
{
    public ModuleRepository(BaseDbContext context) : base(context)
    {
    }
}