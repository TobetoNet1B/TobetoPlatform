using Application.Features.Modules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Modules.Commands.Create;

public class CreateModuleCommand : IRequest<CreatedModuleResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SoftwareLanguageId { get; set; }
    public Guid CompanyId { get; set; }

    public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommand, CreatedModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleRepository _moduleRepository;
        private readonly ModuleBusinessRules _moduleBusinessRules;

        public CreateModuleCommandHandler(IMapper mapper, IModuleRepository moduleRepository,
                                         ModuleBusinessRules moduleBusinessRules)
        {
            _mapper = mapper;
            _moduleRepository = moduleRepository;
            _moduleBusinessRules = moduleBusinessRules;
        }

        public async Task<CreatedModuleResponse> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
        {
            Module module = _mapper.Map<Module>(request);

            await _moduleRepository.AddAsync(module);

            CreatedModuleResponse response = _mapper.Map<CreatedModuleResponse>(module);
            return response;
        }
    }
}