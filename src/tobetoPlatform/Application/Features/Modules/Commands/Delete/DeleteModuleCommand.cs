using Application.Features.Modules.Constants;
using Application.Features.Modules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Modules.Commands.Delete;

public class DeleteModuleCommand : IRequest<DeletedModuleResponse>
{
    public Guid Id { get; set; }

    public class DeleteModuleCommandHandler : IRequestHandler<DeleteModuleCommand, DeletedModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleRepository _moduleRepository;
        private readonly ModuleBusinessRules _moduleBusinessRules;

        public DeleteModuleCommandHandler(IMapper mapper, IModuleRepository moduleRepository,
                                         ModuleBusinessRules moduleBusinessRules)
        {
            _mapper = mapper;
            _moduleRepository = moduleRepository;
            _moduleBusinessRules = moduleBusinessRules;
        }

        public async Task<DeletedModuleResponse> Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
        {
            Module? module = await _moduleRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleBusinessRules.ModuleShouldExistWhenSelected(module);

            await _moduleRepository.DeleteAsync(module!);

            DeletedModuleResponse response = _mapper.Map<DeletedModuleResponse>(module);
            return response;
        }
    }
}