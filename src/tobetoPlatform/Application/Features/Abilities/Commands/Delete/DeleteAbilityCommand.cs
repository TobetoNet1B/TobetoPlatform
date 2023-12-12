using Application.Features.Abilities.Constants;
using Application.Features.Abilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Abilities.Commands.Delete;

public class DeleteAbilityCommand : IRequest<DeletedAbilityResponse>
{
    public Guid Id { get; set; }

    public class DeleteAbilityCommandHandler : IRequestHandler<DeleteAbilityCommand, DeletedAbilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;
        private readonly AbilityBusinessRules _abilityBusinessRules;

        public DeleteAbilityCommandHandler(IMapper mapper, IAbilityRepository abilityRepository,
                                         AbilityBusinessRules abilityBusinessRules)
        {
            _mapper = mapper;
            _abilityRepository = abilityRepository;
            _abilityBusinessRules = abilityBusinessRules;
        }

        public async Task<DeletedAbilityResponse> Handle(DeleteAbilityCommand request, CancellationToken cancellationToken)
        {
            Ability? ability = await _abilityRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _abilityBusinessRules.AbilityShouldExistWhenSelected(ability);

            await _abilityRepository.DeleteAsync(ability!);

            DeletedAbilityResponse response = _mapper.Map<DeletedAbilityResponse>(ability);
            return response;
        }
    }
}