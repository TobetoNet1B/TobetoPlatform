using Application.Features.StudentModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentModules.Commands.Update;

public class UpdateStudentModuleCommand : IRequest<UpdatedStudentModuleResponse>
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleSetId { get; set; }
    public int? TimeSpent { get; set; }

    public class UpdateStudentModuleCommandHandler : IRequestHandler<UpdateStudentModuleCommand, UpdatedStudentModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentModuleRepository _studentModuleRepository;
        private readonly StudentModuleBusinessRules _studentModuleBusinessRules;

        public UpdateStudentModuleCommandHandler(IMapper mapper, IStudentModuleRepository studentModuleRepository,
                                         StudentModuleBusinessRules studentModuleBusinessRules)
        {
            _mapper = mapper;
            _studentModuleRepository = studentModuleRepository;
            _studentModuleBusinessRules = studentModuleBusinessRules;
        }

        public async Task<UpdatedStudentModuleResponse> Handle(UpdateStudentModuleCommand request, CancellationToken cancellationToken)
        {
            StudentModule? studentModule = await _studentModuleRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            await _studentModuleBusinessRules.StudentModuleShouldExistWhenSelected(studentModule);
            studentModule = _mapper.Map(request, studentModule);

            await _studentModuleRepository.UpdateAsync(studentModule!);

            UpdatedStudentModuleResponse response = _mapper.Map<UpdatedStudentModuleResponse>(studentModule);
            return response;
        }
    }
}