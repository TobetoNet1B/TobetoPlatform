using Application.Features.Abilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Abilities.Commands.Update;

public class UpdateAbilityCommand : IRequest<UpdatedAbilityResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int StudentId { get; set; }

    public class UpdateAbilityCommandHandler : IRequestHandler<UpdateAbilityCommand, UpdatedAbilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;
        private readonly AbilityBusinessRules _abilityBusinessRules;

        public UpdateAbilityCommandHandler(IMapper mapper, IAbilityRepository abilityRepository,
                                         AbilityBusinessRules abilityBusinessRules)
        {
            _mapper = mapper;
            _abilityRepository = abilityRepository;
            _abilityBusinessRules = abilityBusinessRules;
        }

        public async Task<UpdatedAbilityResponse> Handle(UpdateAbilityCommand request, CancellationToken cancellationToken)
        {
            Ability? ability = await _abilityRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _abilityBusinessRules.AbilityShouldExistWhenSelected(ability);
            ability = _mapper.Map(request, ability);

            await _abilityRepository.UpdateAsync(ability!);

            UpdatedAbilityResponse response = _mapper.Map<UpdatedAbilityResponse>(ability);
            return response;
        }
    }
}