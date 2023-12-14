using Application.Features.Educations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Educations.Rules;

public class EducationBusinessRules : BaseBusinessRules
{
    private readonly IEducationRepository _educationRepository;

    public EducationBusinessRules(IEducationRepository educationRepository)
    {
        _educationRepository = educationRepository;
    }

    public Task EducationShouldExistWhenSelected(Education? education)
    {
        if (education == null)
            throw new BusinessException(EducationsBusinessMessages.EducationNotExists);
        return Task.CompletedTask;
    }

    public async Task EducationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Education? education = await _educationRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EducationShouldExistWhenSelected(education);
    }
}