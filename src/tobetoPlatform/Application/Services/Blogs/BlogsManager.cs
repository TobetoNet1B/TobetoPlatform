using Application.Features.Blogs.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Blogs;

public class BlogsManager : IBlogsService
{
    private readonly IBlogRepository _blogRepository;
    private readonly BlogBusinessRules _blogBusinessRules;

    public BlogsManager(IBlogRepository blogRepository, BlogBusinessRules blogBusinessRules)
    {
        _blogRepository = blogRepository;
        _blogBusinessRules = blogBusinessRules;
    }

    public async Task<Blog?> GetAsync(
        Expression<Func<Blog, bool>> predicate,
        Func<IQueryable<Blog>, IIncludableQueryable<Blog, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Blog? blog = await _blogRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return blog;
    }

    public async Task<IPaginate<Blog>?> GetListAsync(
        Expression<Func<Blog, bool>>? predicate = null,
        Func<IQueryable<Blog>, IOrderedQueryable<Blog>>? orderBy = null,
        Func<IQueryable<Blog>, IIncludableQueryable<Blog, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Blog> blogList = await _blogRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return blogList;
    }

    public async Task<Blog> AddAsync(Blog blog)
    {
        Blog addedBlog = await _blogRepository.AddAsync(blog);

        return addedBlog;
    }

    public async Task<Blog> UpdateAsync(Blog blog)
    {
        Blog updatedBlog = await _blogRepository.UpdateAsync(blog);

        return updatedBlog;
    }

    public async Task<Blog> DeleteAsync(Blog blog, bool permanent = false)
    {
        Blog deletedBlog = await _blogRepository.DeleteAsync(blog);

        return deletedBlog;
    }
}
