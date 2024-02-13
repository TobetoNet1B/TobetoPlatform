using Application.Features.ModuleTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleTypes.Commands.Update;

public class UpdateModuleTypeCommand : IRequest<UpdatedModuleTypeResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateModuleTypeCommandHandler : IRequestHandler<UpdateModuleTypeCommand, UpdatedModuleTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleTypeRepository _moduleTypeRepository;
        private readonly ModuleTypeBusinessRules _moduleTypeBusinessRules;

        public UpdateModuleTypeCommandHandler(IMapper mapper, IModuleTypeRepository moduleTypeRepository,
                                         ModuleTypeBusinessRules moduleTypeBusinessRules)
        {
            _mapper = mapper;
            _moduleTypeRepository = moduleTypeRepository;
            _moduleTypeBusinessRules = moduleTypeBusinessRules;
        }

        public async Task<UpdatedModuleTypeResponse> Handle(UpdateModuleTypeCommand request, CancellationToken cancellationToken)
        {
            ModuleType? moduleType = await _moduleTypeRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleTypeBusinessRules.ModuleTypeShouldExistWhenSelected(moduleType);
            moduleType = _mapper.Map(request, moduleType);

            await _moduleTypeRepository.UpdateAsync(moduleType!);

            UpdatedModuleTypeResponse response = _mapper.Map<UpdatedModuleTypeResponse>(moduleType);
            return response;
        }
    }
}