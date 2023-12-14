using Application.Features.CourseModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseModules.Queries.GetById;

public class GetByIdCourseModuleQuery : IRequest<GetByIdCourseModuleResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCourseModuleQueryHandler : IRequestHandler<GetByIdCourseModuleQuery, GetByIdCourseModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseModuleRepository _courseModuleRepository;
        private readonly CourseModuleBusinessRules _courseModuleBusinessRules;

        public GetByIdCourseModuleQueryHandler(IMapper mapper, ICourseModuleRepository courseModuleRepository, CourseModuleBusinessRules courseModuleBusinessRules)
        {
            _mapper = mapper;
            _courseModuleRepository = courseModuleRepository;
            _courseModuleBusinessRules = courseModuleBusinessRules;
        }

        public async Task<GetByIdCourseModuleResponse> Handle(GetByIdCourseModuleQuery request, CancellationToken cancellationToken)
        {
            CourseModule? courseModule = await _courseModuleRepository.GetAsync(predicate: cm => cm.Id == request.Id, cancellationToken: cancellationToken);
            await _courseModuleBusinessRules.CourseModuleShouldExistWhenSelected(courseModule);

            GetByIdCourseModuleResponse response = _mapper.Map<GetByIdCourseModuleResponse>(courseModule);
            return response;
        }
    }
}