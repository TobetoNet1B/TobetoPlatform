using Application.Features.Modules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Modules.Queries.GetById;

public class GetByIdModuleQuery : IRequest<GetByIdModuleResponse>
{
    public Guid Id { get; set; }

    public class GetByIdModuleQueryHandler : IRequestHandler<GetByIdModuleQuery, GetByIdModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleRepository _moduleRepository;
        private readonly ModuleBusinessRules _moduleBusinessRules;

        public GetByIdModuleQueryHandler(IMapper mapper, IModuleRepository moduleRepository, ModuleBusinessRules moduleBusinessRules)
        {
            _mapper = mapper;
            _moduleRepository = moduleRepository;
            _moduleBusinessRules = moduleBusinessRules;
        }

        public async Task<GetByIdModuleResponse> Handle(GetByIdModuleQuery request, CancellationToken cancellationToken)
        {
            Module? module = await _moduleRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleBusinessRules.ModuleShouldExistWhenSelected(module);

            GetByIdModuleResponse response = _mapper.Map<GetByIdModuleResponse>(module);
            return response;
        }
    }
}