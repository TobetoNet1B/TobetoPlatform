using Application.Features.ModuleSets.Constants;
using Application.Features.ModuleSets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleSets.Commands.Delete;

public class DeleteModuleSetCommand : IRequest<DeletedModuleSetResponse>
{
    public Guid Id { get; set; }

    public class DeleteModuleSetCommandHandler : IRequestHandler<DeleteModuleSetCommand, DeletedModuleSetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleSetRepository _moduleSetRepository;
        private readonly ModuleSetBusinessRules _moduleSetBusinessRules;

        public DeleteModuleSetCommandHandler(IMapper mapper, IModuleSetRepository moduleSetRepository,
                                         ModuleSetBusinessRules moduleSetBusinessRules)
        {
            _mapper = mapper;
            _moduleSetRepository = moduleSetRepository;
            _moduleSetBusinessRules = moduleSetBusinessRules;
        }

        public async Task<DeletedModuleSetResponse> Handle(DeleteModuleSetCommand request, CancellationToken cancellationToken)
        {
            ModuleSet? moduleSet = await _moduleSetRepository.GetAsync(predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleSetBusinessRules.ModuleSetShouldExistWhenSelected(moduleSet);

            await _moduleSetRepository.DeleteAsync(moduleSet!);

            DeletedModuleSetResponse response = _mapper.Map<DeletedModuleSetResponse>(moduleSet);
            return response;
        }
    }
}