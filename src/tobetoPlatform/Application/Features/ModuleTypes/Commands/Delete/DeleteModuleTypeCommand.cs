using Application.Features.ModuleTypes.Constants;
using Application.Features.ModuleTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleTypes.Commands.Delete;

public class DeleteModuleTypeCommand : IRequest<DeletedModuleTypeResponse>
{
    public Guid Id { get; set; }

    public class DeleteModuleTypeCommandHandler : IRequestHandler<DeleteModuleTypeCommand, DeletedModuleTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleTypeRepository _moduleTypeRepository;
        private readonly ModuleTypeBusinessRules _moduleTypeBusinessRules;

        public DeleteModuleTypeCommandHandler(IMapper mapper, IModuleTypeRepository moduleTypeRepository,
                                         ModuleTypeBusinessRules moduleTypeBusinessRules)
        {
            _mapper = mapper;
            _moduleTypeRepository = moduleTypeRepository;
            _moduleTypeBusinessRules = moduleTypeBusinessRules;
        }

        public async Task<DeletedModuleTypeResponse> Handle(DeleteModuleTypeCommand request, CancellationToken cancellationToken)
        {
            ModuleType? moduleType = await _moduleTypeRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleTypeBusinessRules.ModuleTypeShouldExistWhenSelected(moduleType);

            await _moduleTypeRepository.DeleteAsync(moduleType!);

            DeletedModuleTypeResponse response = _mapper.Map<DeletedModuleTypeResponse>(moduleType);
            return response;
        }
    }
}