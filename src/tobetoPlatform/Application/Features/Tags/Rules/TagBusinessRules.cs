using Application.Features.Tags.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Tags.Rules;

public class TagBusinessRules : BaseBusinessRules
{
    private readonly ITagRepository _tagRepository;

    public TagBusinessRules(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public Task TagShouldExistWhenSelected(Tag? tag)
    {
        if (tag == null)
            throw new BusinessException(TagsBusinessMessages.TagNotExists);
        return Task.CompletedTask;
    }

    public async Task TagIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Tag? tag = await _tagRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TagShouldExistWhenSelected(tag);
    }
}