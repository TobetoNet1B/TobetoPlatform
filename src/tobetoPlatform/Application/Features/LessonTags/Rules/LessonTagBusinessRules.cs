using Application.Features.LessonTags.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LessonTags.Rules;

public class LessonTagBusinessRules : BaseBusinessRules
{
    private readonly ILessonTagRepository _lessonTagRepository;

    public LessonTagBusinessRules(ILessonTagRepository lessonTagRepository)
    {
        _lessonTagRepository = lessonTagRepository;
    }

    public Task LessonTagShouldExistWhenSelected(LessonTag? lessonTag)
    {
        if (lessonTag == null)
            throw new BusinessException(LessonTagsBusinessMessages.LessonTagNotExists);
        return Task.CompletedTask;
    }

    public async Task LessonTagIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        LessonTag? lessonTag = await _lessonTagRepository.GetAsync(
            predicate: lt => lt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LessonTagShouldExistWhenSelected(lessonTag);
    }
}