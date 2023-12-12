using Application.Features.Blogs.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Blogs.Rules;

public class BlogBusinessRules : BaseBusinessRules
{
    private readonly IBlogRepository _blogRepository;

    public BlogBusinessRules(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public Task BlogShouldExistWhenSelected(Blog? blog)
    {
        if (blog == null)
            throw new BusinessException(BlogsBusinessMessages.BlogNotExists);
        return Task.CompletedTask;
    }

    public async Task BlogIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Blog? blog = await _blogRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BlogShouldExistWhenSelected(blog);
    }
}