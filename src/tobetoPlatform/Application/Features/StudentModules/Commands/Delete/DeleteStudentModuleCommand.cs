using Application.Features.StudentModules.Constants;
using Application.Features.StudentModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentModules.Commands.Delete;

public class DeleteStudentModuleCommand : IRequest<DeletedStudentModuleResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentModuleCommandHandler : IRequestHandler<DeleteStudentModuleCommand, DeletedStudentModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentModuleRepository _studentModuleRepository;
        private readonly StudentModuleBusinessRules _studentModuleBusinessRules;

        public DeleteStudentModuleCommandHandler(IMapper mapper, IStudentModuleRepository studentModuleRepository,
                                         StudentModuleBusinessRules studentModuleBusinessRules)
        {
            _mapper = mapper;
            _studentModuleRepository = studentModuleRepository;
            _studentModuleBusinessRules = studentModuleBusinessRules;
        }

        public async Task<DeletedStudentModuleResponse> Handle(DeleteStudentModuleCommand request, CancellationToken cancellationToken)
        {
            StudentModule? studentModule = await _studentModuleRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            await _studentModuleBusinessRules.StudentModuleShouldExistWhenSelected(studentModule);

            await _studentModuleRepository.DeleteAsync(studentModule!);

            DeletedStudentModuleResponse response = _mapper.Map<DeletedStudentModuleResponse>(studentModule);
            return response;
        }
    }
}