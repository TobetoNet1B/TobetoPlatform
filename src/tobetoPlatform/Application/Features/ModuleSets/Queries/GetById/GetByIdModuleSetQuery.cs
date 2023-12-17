using Application.Features.ModuleSets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleSets.Queries.GetById;

public class GetByIdModuleSetQuery : IRequest<GetByIdModuleSetResponse>
{
    public Guid Id { get; set; }

    public class GetByIdModuleSetQueryHandler : IRequestHandler<GetByIdModuleSetQuery, GetByIdModuleSetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleSetRepository _moduleSetRepository;
        private readonly ModuleSetBusinessRules _moduleSetBusinessRules;

        public GetByIdModuleSetQueryHandler(IMapper mapper, IModuleSetRepository moduleSetRepository, ModuleSetBusinessRules moduleSetBusinessRules)
        {
            _mapper = mapper;
            _moduleSetRepository = moduleSetRepository;
            _moduleSetBusinessRules = moduleSetBusinessRules;
        }

        public async Task<GetByIdModuleSetResponse> Handle(GetByIdModuleSetQuery request, CancellationToken cancellationToken)
        {
            ModuleSet? moduleSet = await _moduleSetRepository.GetAsync(predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleSetBusinessRules.ModuleSetShouldExistWhenSelected(moduleSet);

            GetByIdModuleSetResponse response = _mapper.Map<GetByIdModuleSetResponse>(moduleSet);
            return response;
        }
    }
}