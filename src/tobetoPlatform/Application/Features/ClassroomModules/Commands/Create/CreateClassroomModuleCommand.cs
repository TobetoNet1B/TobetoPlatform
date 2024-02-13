using Application.Features.ClassroomModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ClassroomModules.Commands.Create;

public class CreateClassroomModuleCommand : IRequest<CreatedClassroomModuleResponse>
{
    public Guid ClassroomId { get; set; }
    public Guid ModuleSetId { get; set; }
    public DateTime? ClassroomStartDate { get; set; }
    public DateTime? ClassroomEndDate { get; set; }

    public class CreateClassroomModuleCommandHandler : IRequestHandler<CreateClassroomModuleCommand, CreatedClassroomModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomModuleRepository _classroomModuleRepository;
        private readonly ClassroomModuleBusinessRules _classroomModuleBusinessRules;

        public CreateClassroomModuleCommandHandler(IMapper mapper, IClassroomModuleRepository classroomModuleRepository,
                                         ClassroomModuleBusinessRules classroomModuleBusinessRules)
        {
            _mapper = mapper;
            _classroomModuleRepository = classroomModuleRepository;
            _classroomModuleBusinessRules = classroomModuleBusinessRules;
        }

        public async Task<CreatedClassroomModuleResponse> Handle(CreateClassroomModuleCommand request, CancellationToken cancellationToken)
        {
            ClassroomModule classroomModule = _mapper.Map<ClassroomModule>(request);

            await _classroomModuleRepository.AddAsync(classroomModule);

            CreatedClassroomModuleResponse response = _mapper.Map<CreatedClassroomModuleResponse>(classroomModule);
            return response;
        }
    }
}