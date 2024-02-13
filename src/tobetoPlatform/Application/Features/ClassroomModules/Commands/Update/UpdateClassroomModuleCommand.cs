using Application.Features.ClassroomModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ClassroomModules.Commands.Update;

public class UpdateClassroomModuleCommand : IRequest<UpdatedClassroomModuleResponse>
{
    public Guid Id { get; set; }
    public Guid ClassroomId { get; set; }
    public Guid ModuleSetId { get; set; }
    public DateTime? ClassroomStartDate { get; set; }
    public DateTime? ClassroomEndDate { get; set; }

    public class UpdateClassroomModuleCommandHandler : IRequestHandler<UpdateClassroomModuleCommand, UpdatedClassroomModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomModuleRepository _classroomModuleRepository;
        private readonly ClassroomModuleBusinessRules _classroomModuleBusinessRules;

        public UpdateClassroomModuleCommandHandler(IMapper mapper, IClassroomModuleRepository classroomModuleRepository,
                                         ClassroomModuleBusinessRules classroomModuleBusinessRules)
        {
            _mapper = mapper;
            _classroomModuleRepository = classroomModuleRepository;
            _classroomModuleBusinessRules = classroomModuleBusinessRules;
        }

        public async Task<UpdatedClassroomModuleResponse> Handle(UpdateClassroomModuleCommand request, CancellationToken cancellationToken)
        {
            ClassroomModule? classroomModule = await _classroomModuleRepository.GetAsync(predicate: cm => cm.Id == request.Id, cancellationToken: cancellationToken);
            await _classroomModuleBusinessRules.ClassroomModuleShouldExistWhenSelected(classroomModule);
            classroomModule = _mapper.Map(request, classroomModule);

            await _classroomModuleRepository.UpdateAsync(classroomModule!);

            UpdatedClassroomModuleResponse response = _mapper.Map<UpdatedClassroomModuleResponse>(classroomModule);
            return response;
        }
    }
}