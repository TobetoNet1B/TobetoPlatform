using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICategoryOfModuleSetRepository : IAsyncRepository<CategoryOfModuleSet, Guid>, IRepository<CategoryOfModuleSet, Guid>
{
}