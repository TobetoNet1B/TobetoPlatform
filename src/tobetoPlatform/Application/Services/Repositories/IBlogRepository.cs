using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBlogRepository : IAsyncRepository<Blog, Guid>, IRepository<Blog, Guid>
{
}