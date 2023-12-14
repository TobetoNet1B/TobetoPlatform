using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Blogs;

public interface IBlogsService
{
    Task<Blog?> GetAsync(
        Expression<Func<Blog, bool>> predicate,
        Func<IQueryable<Blog>, IIncludableQueryable<Blog, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Blog>?> GetListAsync(
        Expression<Func<Blog, bool>>? predicate = null,
        Func<IQueryable<Blog>, IOrderedQueryable<Blog>>? orderBy = null,
        Func<IQueryable<Blog>, IIncludableQueryable<Blog, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Blog> AddAsync(Blog blog);
    Task<Blog> UpdateAsync(Blog blog);
    Task<Blog> DeleteAsync(Blog blog, bool permanent = false);
}
