using Application.Features.ModuleSets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleSets.Commands.Update;

public class UpdateModuleSetCommand : IRequest<UpdatedModuleSetResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SoftwareLanguageId { get; set; }
    public Guid CompanyId { get; set; }

    public class UpdateModuleSetCommandHandler : IRequestHandler<UpdateModuleSetCommand, UpdatedModuleSetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleSetRepository _moduleSetRepository;
        private readonly ModuleSetBusinessRules _moduleSetBusinessRules;

        public UpdateModuleSetCommandHandler(IMapper mapper, IModuleSetRepository moduleSetRepository,
                                         ModuleSetBusinessRules moduleSetBusinessRules)
        {
            _mapper = mapper;
            _moduleSetRepository = moduleSetRepository;
            _moduleSetBusinessRules = moduleSetBusinessRules;
        }

        public async Task<UpdatedModuleSetResponse> Handle(UpdateModuleSetCommand request, CancellationToken cancellationToken)
        {
            ModuleSet? moduleSet = await _moduleSetRepository.GetAsync(predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleSetBusinessRules.ModuleSetShouldExistWhenSelected(moduleSet);
            moduleSet = _mapper.Map(request, moduleSet);

            await _moduleSetRepository.UpdateAsync(moduleSet!);

            UpdatedModuleSetResponse response = _mapper.Map<UpdatedModuleSetResponse>(moduleSet);
            return response;
        }
    }
}