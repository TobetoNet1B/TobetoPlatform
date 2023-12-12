using Application.Features.Abilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Abilities.Commands.Create;

public class CreateAbilityCommand : IRequest<CreatedAbilityResponse>
{
    public string Name { get; set; }
    public int StudentId { get; set; }

    public class CreateAbilityCommandHandler : IRequestHandler<CreateAbilityCommand, CreatedAbilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;
        private readonly AbilityBusinessRules _abilityBusinessRules;

        public CreateAbilityCommandHandler(IMapper mapper, IAbilityRepository abilityRepository,
                                         AbilityBusinessRules abilityBusinessRules)
        {
            _mapper = mapper;
            _abilityRepository = abilityRepository;
            _abilityBusinessRules = abilityBusinessRules;
        }

        public async Task<CreatedAbilityResponse> Handle(CreateAbilityCommand request, CancellationToken cancellationToken)
        {
            await _abilityBusinessRules.AbilityNameCanBotBeDuplicationWhenInserted(request.Name);
            Ability ability = _mapper.Map<Ability>(request);

            await _abilityRepository.AddAsync(ability);

            CreatedAbilityResponse response = _mapper.Map<CreatedAbilityResponse>(ability);
            return response;
        }
    }
}