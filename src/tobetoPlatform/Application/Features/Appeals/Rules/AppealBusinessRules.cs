using Application.Features.Abilities.Constants;
using Application.Features.Appeals.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Appeals.Rules;

public class AppealBusinessRules : BaseBusinessRules
{
    private readonly IAppealRepository _appealRepository;

    public AppealBusinessRules(IAppealRepository appealRepository)
    {
        _appealRepository = appealRepository;
    }

    public Task AppealShouldExistWhenSelected(Appeal? appeal)
    {
        if (appeal == null)
            throw new BusinessException(AppealsBusinessMessages.AppealNotExists);
        return Task.CompletedTask;
    }

    public async Task AppealIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Appeal? appeal = await _appealRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AppealShouldExistWhenSelected(appeal);
    }

    public async Task AppealNameCanNotBeDuplicationWhenInserted(string name)
    {
        IPaginate<Appeal> result = await _appealRepository.GetListAsync(c => c.Name == name);
        if (result.Items.Any())
            throw new Exception(AppealsBusinessMessages.AppealNameExists);
    }
}