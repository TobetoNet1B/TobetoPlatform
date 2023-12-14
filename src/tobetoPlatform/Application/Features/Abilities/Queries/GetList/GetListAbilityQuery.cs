using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Abilities.Queries.GetList;

public class GetListAbilityQuery : IRequest<GetListResponse<GetListAbilityListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAbilityQueryHandler : IRequestHandler<GetListAbilityQuery, GetListResponse<GetListAbilityListItemDto>>
    {
        private readonly IAbilityRepository _abilityRepository;
        private readonly IMapper _mapper;

        public GetListAbilityQueryHandler(IAbilityRepository abilityRepository, IMapper mapper)
        {
            _abilityRepository = abilityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAbilityListItemDto>> Handle(GetListAbilityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Ability> abilities = await _abilityRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAbilityListItemDto> response = _mapper.Map<GetListResponse<GetListAbilityListItemDto>>(abilities);
            return response;
        }
    }
}