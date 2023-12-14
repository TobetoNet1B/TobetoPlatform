using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseModuleRepository : EfRepositoryBase<CourseModule, Guid, BaseDbContext>, ICourseModuleRepository
{
    public CourseModuleRepository(BaseDbContext context) : base(context)
    {
    }
}