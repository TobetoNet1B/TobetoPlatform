using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseStudentRepository : EfRepositoryBase<CourseStudent, Guid, BaseDbContext>, ICourseStudentRepository
{
    public CourseStudentRepository(BaseDbContext context) : base(context)
    {
    }
}