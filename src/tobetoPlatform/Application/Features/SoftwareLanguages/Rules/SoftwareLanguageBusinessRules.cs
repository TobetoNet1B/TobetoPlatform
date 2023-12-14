using Application.Features.SoftwareLanguages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SoftwareLanguages.Rules;

public class SoftwareLanguageBusinessRules : BaseBusinessRules
{
    private readonly ISoftwareLanguageRepository _softwareLanguageRepository;

    public SoftwareLanguageBusinessRules(ISoftwareLanguageRepository softwareLanguageRepository)
    {
        _softwareLanguageRepository = softwareLanguageRepository;
    }

    public Task SoftwareLanguageShouldExistWhenSelected(SoftwareLanguage? softwareLanguage)
    {
        if (softwareLanguage == null)
            throw new BusinessException(SoftwareLanguagesBusinessMessages.SoftwareLanguageNotExists);
        return Task.CompletedTask;
    }

    public async Task SoftwareLanguageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SoftwareLanguage? softwareLanguage = await _softwareLanguageRepository.GetAsync(
            predicate: sl => sl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SoftwareLanguageShouldExistWhenSelected(softwareLanguage);
    }
}