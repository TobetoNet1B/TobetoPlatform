using Application.Features.ModuleTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleTypes.Commands.Create;

public class CreateModuleTypeCommand : IRequest<CreatedModuleTypeResponse>
{
    public string Name { get; set; }

    public class CreateModuleTypeCommandHandler : IRequestHandler<CreateModuleTypeCommand, CreatedModuleTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleTypeRepository _moduleTypeRepository;
        private readonly ModuleTypeBusinessRules _moduleTypeBusinessRules;

        public CreateModuleTypeCommandHandler(IMapper mapper, IModuleTypeRepository moduleTypeRepository,
                                         ModuleTypeBusinessRules moduleTypeBusinessRules)
        {
            _mapper = mapper;
            _moduleTypeRepository = moduleTypeRepository;
            _moduleTypeBusinessRules = moduleTypeBusinessRules;
        }

        public async Task<CreatedModuleTypeResponse> Handle(CreateModuleTypeCommand request, CancellationToken cancellationToken)
        {
            ModuleType moduleType = _mapper.Map<ModuleType>(request);

            await _moduleTypeRepository.AddAsync(moduleType);

            CreatedModuleTypeResponse response = _mapper.Map<CreatedModuleTypeResponse>(moduleType);
            return response;
        }
    }
}