using Application.Features.Abilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Abilities.Queries.GetById;

public class GetByIdAbilityQuery : IRequest<List<GetByIdAbilityResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdAbilityQueryHandler : IRequestHandler<GetByIdAbilityQuery,List<GetByIdAbilityResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;
        private readonly AbilityBusinessRules _abilityBusinessRules;

        public GetByIdAbilityQueryHandler(IMapper mapper, IAbilityRepository abilityRepository, AbilityBusinessRules abilityBusinessRules)
        {
            _mapper = mapper;
            _abilityRepository = abilityRepository;
            _abilityBusinessRules = abilityBusinessRules;
        }

        public async Task<List<GetByIdAbilityResponse>> Handle(GetByIdAbilityQuery request, CancellationToken cancellationToken)
        {
            var abilities = await _abilityRepository.GetListAsync(
            predicate: a => a.StudentId == request.Id,
            cancellationToken: cancellationToken);
            //await _abilityBusinessRules.AbilityShouldExistWhenSelected(ability);

            List<GetByIdAbilityResponse> response = _mapper.Map<List<GetByIdAbilityResponse>>(abilities.Items);
            return response;

            /*Ability? ability = await _abilityRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _abilityBusinessRules.AbilityShouldExistWhenSelected(ability);

            GetByIdAbilityResponse response = _mapper.Map<GetByIdAbilityResponse>(ability);
            return response;*/
        }
    }
}