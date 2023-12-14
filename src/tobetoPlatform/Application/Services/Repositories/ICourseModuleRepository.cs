using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseModuleRepository : IAsyncRepository<CourseModule, Guid>, IRepository<CourseModule, Guid>
{
}