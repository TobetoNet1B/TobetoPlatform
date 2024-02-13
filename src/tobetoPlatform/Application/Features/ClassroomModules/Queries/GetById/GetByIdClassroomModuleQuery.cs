using Application.Features.ClassroomModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ClassroomModules.Queries.GetById;

public class GetByIdClassroomModuleQuery : IRequest<GetByIdClassroomModuleResponse>
{
    public Guid Id { get; set; }

    public class GetByIdClassroomModuleQueryHandler : IRequestHandler<GetByIdClassroomModuleQuery, GetByIdClassroomModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomModuleRepository _classroomModuleRepository;
        private readonly ClassroomModuleBusinessRules _classroomModuleBusinessRules;

        public GetByIdClassroomModuleQueryHandler(IMapper mapper, IClassroomModuleRepository classroomModuleRepository, ClassroomModuleBusinessRules classroomModuleBusinessRules)
        {
            _mapper = mapper;
            _classroomModuleRepository = classroomModuleRepository;
            _classroomModuleBusinessRules = classroomModuleBusinessRules;
        }

        public async Task<GetByIdClassroomModuleResponse> Handle(GetByIdClassroomModuleQuery request, CancellationToken cancellationToken)
        {
            ClassroomModule? classroomModule = await _classroomModuleRepository.GetAsync(predicate: cm => cm.Id == request.Id, cancellationToken: cancellationToken);
            await _classroomModuleBusinessRules.ClassroomModuleShouldExistWhenSelected(classroomModule);

            GetByIdClassroomModuleResponse response = _mapper.Map<GetByIdClassroomModuleResponse>(classroomModule);
            return response;
        }
    }
}