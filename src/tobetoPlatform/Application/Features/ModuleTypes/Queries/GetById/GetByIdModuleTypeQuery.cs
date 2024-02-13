using Application.Features.ModuleTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleTypes.Queries.GetById;

public class GetByIdModuleTypeQuery : IRequest<GetByIdModuleTypeResponse>
{
    public Guid Id { get; set; }

    public class GetByIdModuleTypeQueryHandler : IRequestHandler<GetByIdModuleTypeQuery, GetByIdModuleTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleTypeRepository _moduleTypeRepository;
        private readonly ModuleTypeBusinessRules _moduleTypeBusinessRules;

        public GetByIdModuleTypeQueryHandler(IMapper mapper, IModuleTypeRepository moduleTypeRepository, ModuleTypeBusinessRules moduleTypeBusinessRules)
        {
            _mapper = mapper;
            _moduleTypeRepository = moduleTypeRepository;
            _moduleTypeBusinessRules = moduleTypeBusinessRules;
        }

        public async Task<GetByIdModuleTypeResponse> Handle(GetByIdModuleTypeQuery request, CancellationToken cancellationToken)
        {
            ModuleType? moduleType = await _moduleTypeRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleTypeBusinessRules.ModuleTypeShouldExistWhenSelected(moduleType);

            GetByIdModuleTypeResponse response = _mapper.Map<GetByIdModuleTypeResponse>(moduleType);
            return response;
        }
    }
}