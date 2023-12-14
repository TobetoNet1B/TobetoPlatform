using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAddressRepository : IAsyncRepository<Address, Guid>, IRepository<Address, Guid>
{
}