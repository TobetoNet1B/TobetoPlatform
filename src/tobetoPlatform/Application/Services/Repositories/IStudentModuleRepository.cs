using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentModuleRepository : IAsyncRepository<StudentModule, Guid>, IRepository<StudentModule, Guid>
{
}