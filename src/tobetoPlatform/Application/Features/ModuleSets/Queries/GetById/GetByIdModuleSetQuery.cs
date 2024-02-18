using Application.Features.ModuleSets.Rules;
using Application.Features.Students.Queries.GetById;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ModuleSets.Queries.GetById;

public class GetByIdModuleSetQuery : IRequest<GetByIdModuleSetResponse>
{
    public Guid Id { get; set; }

    public class GetByIdModuleSetQueryHandler : IRequestHandler<GetByIdModuleSetQuery, GetByIdModuleSetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleSetRepository _moduleSetRepository;
        private readonly ModuleSetBusinessRules _moduleSetBusinessRules;

        public GetByIdModuleSetQueryHandler(IMapper mapper, IModuleSetRepository moduleSetRepository, ModuleSetBusinessRules moduleSetBusinessRules)
        {
            _mapper = mapper;
            _moduleSetRepository = moduleSetRepository;
            _moduleSetBusinessRules = moduleSetBusinessRules;
        }

        public async Task<GetByIdModuleSetResponse> Handle(GetByIdModuleSetQuery request, CancellationToken cancellationToken)
        {
            ModuleSet? moduleSet = await _moduleSetRepository.GetAsync(
              include: m => m.Include(s => s.Company)
                            .Include(s => s.StudentModules)
                            .Include(s => s.ModuleSetCategorys).ThenInclude(s=>s.CategoryOfModuleSet)
                            .Include(s => s.CourseModules).ThenInclude(s => s.Course).ThenInclude(s=>s.Lessons)
            , predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleSetBusinessRules.ModuleSetShouldExistWhenSelected(moduleSet);

            GetByIdModuleSetResponse response = _mapper.Map<GetByIdModuleSetResponse>(moduleSet);

            response.Company = _mapper.Map<CompanyDto>(moduleSet.Company);
            response.CourseModules = moduleSet.CourseModules.Select(ms => _mapper.Map<CourseModuleDto>(ms)).ToList();

            response.StudentModules = moduleSet.StudentModules.Select(ms => _mapper.Map<StudentModuleDto>(ms)).ToList();

            response.ModuleSetCategorys = moduleSet.ModuleSetCategorys.Select(ms => _mapper.Map<ModuleSetCategoryDto>(ms)).ToList();
            return response;

        }
    }
}