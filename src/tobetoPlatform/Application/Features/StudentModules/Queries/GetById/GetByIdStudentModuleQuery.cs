using Application.Features.StudentModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentModules.Queries.GetById;

public class GetByIdStudentModuleQuery : IRequest<GetByIdStudentModuleResponse>
{
    public Guid Id { get; set; }

    public class GetByIdStudentModuleQueryHandler : IRequestHandler<GetByIdStudentModuleQuery, GetByIdStudentModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentModuleRepository _studentModuleRepository;
        private readonly StudentModuleBusinessRules _studentModuleBusinessRules;

        public GetByIdStudentModuleQueryHandler(IMapper mapper, IStudentModuleRepository studentModuleRepository, StudentModuleBusinessRules studentModuleBusinessRules)
        {
            _mapper = mapper;
            _studentModuleRepository = studentModuleRepository;
            _studentModuleBusinessRules = studentModuleBusinessRules;
        }

        public async Task<GetByIdStudentModuleResponse> Handle(GetByIdStudentModuleQuery request, CancellationToken cancellationToken)
        {
            StudentModule? studentModule = await _studentModuleRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            await _studentModuleBusinessRules.StudentModuleShouldExistWhenSelected(studentModule);

            GetByIdStudentModuleResponse response = _mapper.Map<GetByIdStudentModuleResponse>(studentModule);
            return response;
        }
    }
}