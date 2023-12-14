using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICompanyRepository : IAsyncRepository<Company, Guid>, IRepository<Company, Guid>
{
}