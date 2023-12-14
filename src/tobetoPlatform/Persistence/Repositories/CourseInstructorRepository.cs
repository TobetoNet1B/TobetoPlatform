using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseInstructorRepository : EfRepositoryBase<CourseInstructor, Guid, BaseDbContext>, ICourseInstructorRepository
{
    public CourseInstructorRepository(BaseDbContext context) : base(context)
    {
    }
}