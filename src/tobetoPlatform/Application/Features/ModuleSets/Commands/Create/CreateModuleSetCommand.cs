using Application.Features.ModuleSets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleSets.Commands.Create;

public class CreateModuleSetCommand : IRequest<CreatedModuleSetResponse>
{
    public string Name { get; set; }
    public string? EducationType { get; set; }
    public string? CourseLevel { get; set; }
    public string? Topic { get; set; }
    public Guid? SoftwareLanguageId { get; set; }
    public Guid? InstructorId { get; set; }
    public string? ActivityStatus { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? EstimatedTime { get; set; }
    public string? ImgUrl { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? ModuleTypeId { get; set; }

    public class CreateModuleSetCommandHandler : IRequestHandler<CreateModuleSetCommand, CreatedModuleSetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleSetRepository _moduleSetRepository;
        private readonly ModuleSetBusinessRules _moduleSetBusinessRules;

        public CreateModuleSetCommandHandler(IMapper mapper, IModuleSetRepository moduleSetRepository,
                                         ModuleSetBusinessRules moduleSetBusinessRules)
        {
            _mapper = mapper;
            _moduleSetRepository = moduleSetRepository;
            _moduleSetBusinessRules = moduleSetBusinessRules;
        }

        public async Task<CreatedModuleSetResponse> Handle(CreateModuleSetCommand request, CancellationToken cancellationToken)
        {
            ModuleSet moduleSet = _mapper.Map<ModuleSet>(request);

            await _moduleSetRepository.AddAsync(moduleSet);

            CreatedModuleSetResponse response = _mapper.Map<CreatedModuleSetResponse>(moduleSet);
            return response;
        }
    }
}