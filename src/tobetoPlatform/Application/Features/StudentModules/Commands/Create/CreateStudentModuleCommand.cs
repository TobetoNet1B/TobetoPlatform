using Application.Features.StudentModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentModules.Commands.Create;

public class CreateStudentModuleCommand : IRequest<CreatedStudentModuleResponse>
{
    public Guid StudentId { get; set; }
    public Guid ModuleSetId { get; set; }
    public int? TimeSpent { get; set; }
    public bool? IsCompleted { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsFav { get; set; }

    public class CreateStudentModuleCommandHandler : IRequestHandler<CreateStudentModuleCommand, CreatedStudentModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentModuleRepository _studentModuleRepository;
        private readonly StudentModuleBusinessRules _studentModuleBusinessRules;

        public CreateStudentModuleCommandHandler(IMapper mapper, IStudentModuleRepository studentModuleRepository,
                                         StudentModuleBusinessRules studentModuleBusinessRules)
        {
            _mapper = mapper;
            _studentModuleRepository = studentModuleRepository;
            _studentModuleBusinessRules = studentModuleBusinessRules;
        }

        public async Task<CreatedStudentModuleResponse> Handle(CreateStudentModuleCommand request, CancellationToken cancellationToken)
        {
            StudentModule studentModule = _mapper.Map<StudentModule>(request);

            await _studentModuleRepository.AddAsync(studentModule);

            CreatedStudentModuleResponse response = _mapper.Map<CreatedStudentModuleResponse>(studentModule);
            return response;
        }
    }
}