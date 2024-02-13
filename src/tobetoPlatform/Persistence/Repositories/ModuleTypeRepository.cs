using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModuleTypeRepository : EfRepositoryBase<ModuleType, Guid, BaseDbContext>, IModuleTypeRepository
{
    public ModuleTypeRepository(BaseDbContext context) : base(context)
    {
    }
}