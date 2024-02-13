using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CategoryOfModuleSetRepository : EfRepositoryBase<CategoryOfModuleSet, Guid, BaseDbContext>, ICategoryOfModuleSetRepository
{
    public CategoryOfModuleSetRepository(BaseDbContext context) : base(context)
    {
    }
}