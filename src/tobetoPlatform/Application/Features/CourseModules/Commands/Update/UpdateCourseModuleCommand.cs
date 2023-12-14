using Application.Features.CourseModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseModules.Commands.Update;

public class UpdateCourseModuleCommand : IRequest<UpdatedCourseModuleResponse>
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid ModuleId { get; set; }

    public class UpdateCourseModuleCommandHandler : IRequestHandler<UpdateCourseModuleCommand, UpdatedCourseModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseModuleRepository _courseModuleRepository;
        private readonly CourseModuleBusinessRules _courseModuleBusinessRules;

        public UpdateCourseModuleCommandHandler(IMapper mapper, ICourseModuleRepository courseModuleRepository,
                                         CourseModuleBusinessRules courseModuleBusinessRules)
        {
            _mapper = mapper;
            _courseModuleRepository = courseModuleRepository;
            _courseModuleBusinessRules = courseModuleBusinessRules;
        }

        public async Task<UpdatedCourseModuleResponse> Handle(UpdateCourseModuleCommand request, CancellationToken cancellationToken)
        {
            CourseModule? courseModule = await _courseModuleRepository.GetAsync(predicate: cm => cm.Id == request.Id, cancellationToken: cancellationToken);
            await _courseModuleBusinessRules.CourseModuleShouldExistWhenSelected(courseModule);
            courseModule = _mapper.Map(request, courseModule);

            await _courseModuleRepository.UpdateAsync(courseModule!);

            UpdatedCourseModuleResponse response = _mapper.Map<UpdatedCourseModuleResponse>(courseModule);
            return response;
        }
    }
}