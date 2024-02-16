using Application.Features.ModuleSets.Queries.GetById;
using Application.Features.StudentModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            //StudentModule? studentModule = await _studentModuleRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            //await _studentModuleBusinessRules.StudentModuleShouldExistWhenSelected(studentModule);

            //GetByIdStudentModuleResponse response = _mapper.Map<GetByIdStudentModuleResponse>(studentModule);
            //return response;
            IPaginate<StudentModule> studentModules = await _studentModuleRepository.GetListAsync(
     predicate: sm => sm.StudentId == request.Id,
     include: m => m.Include(s => s.Student)
                     .Include(s => s.ModuleSet)
                         .ThenInclude(ms => ms.Company),
     cancellationToken: cancellationToken);



            GetByIdStudentModuleResponse response = new GetByIdStudentModuleResponse
            {
                Student = _mapper.Map<StudentDto>(studentModules.Items.FirstOrDefault()?.Student),
                ModuleSets = studentModules.Items.Select(se => _mapper.Map<ModuleSetDto>(se.ModuleSet)).ToList(),
                TimeSpent = studentModules.Items.FirstOrDefault()?.TimeSpent
            };


            return response;
        }
    }
}