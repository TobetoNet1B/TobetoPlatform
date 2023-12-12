using Application.Features.SocialMedias.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SocialMedias.Rules;

public class SocialMediaBusinessRules : BaseBusinessRules
{
    private readonly ISocialMediaRepository _socialMediaRepository;

    public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository)
    {
        _socialMediaRepository = socialMediaRepository;
    }

    public Task SocialMediaShouldExistWhenSelected(SocialMedia? socialMedia)
    {
        if (socialMedia == null)
            throw new BusinessException(SocialMediasBusinessMessages.SocialMediaNotExists);
        return Task.CompletedTask;
    }

    public async Task SocialMediaIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(
            predicate: sm => sm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SocialMediaShouldExistWhenSelected(socialMedia);
    }
}