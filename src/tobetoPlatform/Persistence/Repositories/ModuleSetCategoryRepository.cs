using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModuleSetCategoryRepository : EfRepositoryBase<ModuleSetCategory, Guid, BaseDbContext>, IModuleSetCategoryRepository
{
    public ModuleSetCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}