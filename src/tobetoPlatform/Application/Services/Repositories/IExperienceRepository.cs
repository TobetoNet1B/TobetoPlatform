using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IExperienceRepository : IAsyncRepository<Experience, Guid>, IRepository<Experience, Guid>
{
}