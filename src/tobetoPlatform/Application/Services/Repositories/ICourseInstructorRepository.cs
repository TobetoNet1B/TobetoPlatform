using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseInstructorRepository : IAsyncRepository<CourseInstructor, Guid>, IRepository<CourseInstructor, Guid>
{
}