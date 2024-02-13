using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICategoryRepository : IAsyncRepository<CategoryOfModuleSet, Guid>, IRepository<CategoryOfModuleSet, Guid>
{
}