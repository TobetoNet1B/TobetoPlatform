using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseStudentRepository : IAsyncRepository<CourseStudent, Guid>, IRepository<CourseStudent, Guid>
{
}