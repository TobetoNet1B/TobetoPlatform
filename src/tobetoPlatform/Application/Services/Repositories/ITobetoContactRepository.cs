using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITobetoContactRepository : IAsyncRepository<TobetoContact, Guid>, IRepository<TobetoContact, Guid>
{
}