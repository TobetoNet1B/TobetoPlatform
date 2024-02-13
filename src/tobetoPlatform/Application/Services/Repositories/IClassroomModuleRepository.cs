using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IClassroomModuleRepository : IAsyncRepository<ClassroomModule, Guid>, IRepository<ClassroomModule, Guid>
{
}