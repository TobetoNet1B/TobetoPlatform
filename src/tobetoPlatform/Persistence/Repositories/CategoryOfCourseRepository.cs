using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CategoryOfCourseRepository : EfRepositoryBase<CategoryOfCourse, Guid, BaseDbContext>, ICategoryOfCourseRepository
{
    public CategoryOfCourseRepository(BaseDbContext context) : base(context)
    {
    }
}