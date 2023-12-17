using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModuleSetRepository : EfRepositoryBase<ModuleSet, Guid, BaseDbContext>, IModuleSetRepository
{
    public ModuleSetRepository(BaseDbContext context) : base(context)
    {
    }
}