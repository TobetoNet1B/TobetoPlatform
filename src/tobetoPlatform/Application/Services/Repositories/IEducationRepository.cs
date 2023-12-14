using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEducationRepository : IAsyncRepository<Education, Guid>, IRepository<Education, Guid>
{
}