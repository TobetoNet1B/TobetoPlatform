using Application.Features.Modules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Modules.Commands.Update;

public class UpdateModuleCommand : IRequest<UpdatedModuleResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SoftwareLanguageId { get; set; }
    public Guid CompanyId { get; set; }

    public class UpdateModuleCommandHandler : IRequestHandler<UpdateModuleCommand, UpdatedModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleRepository _moduleRepository;
        private readonly ModuleBusinessRules _moduleBusinessRules;

        public UpdateModuleCommandHandler(IMapper mapper, IModuleRepository moduleRepository,
                                         ModuleBusinessRules moduleBusinessRules)
        {
            _mapper = mapper;
            _moduleRepository = moduleRepository;
            _moduleBusinessRules = moduleBusinessRules;
        }

        public async Task<UpdatedModuleResponse> Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
        {
            Module? module = await _moduleRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleBusinessRules.ModuleShouldExistWhenSelected(module);
            module = _mapper.Map(request, module);

            await _moduleRepository.UpdateAsync(module!);

            UpdatedModuleResponse response = _mapper.Map<UpdatedModuleResponse>(module);
            return response;
        }
    }
}