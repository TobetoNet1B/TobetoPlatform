using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICategoryOfCourseRepository : IAsyncRepository<CategoryOfCourse, Guid>, IRepository<CategoryOfCourse, Guid>
{
}