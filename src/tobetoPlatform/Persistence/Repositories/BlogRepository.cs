using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BlogRepository : EfRepositoryBase<Blog, Guid, BaseDbContext>, IBlogRepository
{
    public BlogRepository(BaseDbContext context) : base(context)
    {
    }
}