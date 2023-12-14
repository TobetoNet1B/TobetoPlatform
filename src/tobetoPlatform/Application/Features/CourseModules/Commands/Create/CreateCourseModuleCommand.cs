using Application.Features.CourseModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseModules.Commands.Create;

public class CreateCourseModuleCommand : IRequest<CreatedCourseModuleResponse>
{
    public Guid CourseId { get; set; }
    public Guid ModuleId { get; set; }

    public class CreateCourseModuleCommandHandler : IRequestHandler<CreateCourseModuleCommand, CreatedCourseModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseModuleRepository _courseModuleRepository;
        private readonly CourseModuleBusinessRules _courseModuleBusinessRules;

        public CreateCourseModuleCommandHandler(IMapper mapper, ICourseModuleRepository courseModuleRepository,
                                         CourseModuleBusinessRules courseModuleBusinessRules)
        {
            _mapper = mapper;
            _courseModuleRepository = courseModuleRepository;
            _courseModuleBusinessRules = courseModuleBusinessRules;
        }

        public async Task<CreatedCourseModuleResponse> Handle(CreateCourseModuleCommand request, CancellationToken cancellationToken)
        {
            CourseModule courseModule = _mapper.Map<CourseModule>(request);

            await _courseModuleRepository.AddAsync(courseModule);

            CreatedCourseModuleResponse response = _mapper.Map<CreatedCourseModuleResponse>(courseModule);
            return response;
        }
    }
}