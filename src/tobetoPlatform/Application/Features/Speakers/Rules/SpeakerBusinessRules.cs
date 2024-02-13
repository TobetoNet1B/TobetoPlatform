using Application.Features.Speakers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Speakers.Rules;

public class SpeakerBusinessRules : BaseBusinessRules
{
    private readonly ISpeakerRepository _speakerRepository;

    public SpeakerBusinessRules(ISpeakerRepository speakerRepository)
    {
        _speakerRepository = speakerRepository;
    }

    public Task SpeakerShouldExistWhenSelected(Speaker? speaker)
    {
        if (speaker == null)
            throw new BusinessException(SpeakersBusinessMessages.SpeakerNotExists);
        return Task.CompletedTask;
    }

    public async Task SpeakerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Speaker? speaker = await _speakerRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SpeakerShouldExistWhenSelected(speaker);
    }
}