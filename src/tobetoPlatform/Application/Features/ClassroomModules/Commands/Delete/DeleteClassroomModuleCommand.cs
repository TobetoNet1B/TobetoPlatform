using Application.Features.ClassroomModules.Constants;
using Application.Features.ClassroomModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ClassroomModules.Commands.Delete;

public class DeleteClassroomModuleCommand : IRequest<DeletedClassroomModuleResponse>
{
    public Guid Id { get; set; }

    public class DeleteClassroomModuleCommandHandler : IRequestHandler<DeleteClassroomModuleCommand, DeletedClassroomModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomModuleRepository _classroomModuleRepository;
        private readonly ClassroomModuleBusinessRules _classroomModuleBusinessRules;

        public DeleteClassroomModuleCommandHandler(IMapper mapper, IClassroomModuleRepository classroomModuleRepository,
                                         ClassroomModuleBusinessRules classroomModuleBusinessRules)
        {
            _mapper = mapper;
            _classroomModuleRepository = classroomModuleRepository;
            _classroomModuleBusinessRules = classroomModuleBusinessRules;
        }

        public async Task<DeletedClassroomModuleResponse> Handle(DeleteClassroomModuleCommand request, CancellationToken cancellationToken)
        {
            ClassroomModule? classroomModule = await _classroomModuleRepository.GetAsync(predicate: cm => cm.Id == request.Id, cancellationToken: cancellationToken);
            await _classroomModuleBusinessRules.ClassroomModuleShouldExistWhenSelected(classroomModule);

            await _classroomModuleRepository.DeleteAsync(classroomModule!);

            DeletedClassroomModuleResponse response = _mapper.Map<DeletedClassroomModuleResponse>(classroomModule);
            return response;
        }
    }
}