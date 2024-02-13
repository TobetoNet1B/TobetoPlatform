using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ClassroomModuleRepository : EfRepositoryBase<ClassroomModule, Guid, BaseDbContext>, IClassroomModuleRepository
{
    public ClassroomModuleRepository(BaseDbContext context) : base(context)
    {
    }
}