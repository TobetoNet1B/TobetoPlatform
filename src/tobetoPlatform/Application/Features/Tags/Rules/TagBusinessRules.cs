using Application.Features.Tags.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
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
    public async Task TagNameCanBotBeDuplicationWhenInserted(string name)
    {
        IPaginate<Tag> result = await _tagRepository.GetListAsync(c => c.TagName == name);
        if (result.Items.Any())
            throw new Exception("Tag name exitst");
    }
}