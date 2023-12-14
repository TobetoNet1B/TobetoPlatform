using Application.Features.CourseModules.Constants;
using Application.Features.CourseModules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseModules.Commands.Delete;

public class DeleteCourseModuleCommand : IRequest<DeletedCourseModuleResponse>
{
    public Guid Id { get; set; }

    public class DeleteCourseModuleCommandHandler : IRequestHandler<DeleteCourseModuleCommand, DeletedCourseModuleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseModuleRepository _courseModuleRepository;
        private readonly CourseModuleBusinessRules _courseModuleBusinessRules;

        public DeleteCourseModuleCommandHandler(IMapper mapper, ICourseModuleRepository courseModuleRepository,
                                         CourseModuleBusinessRules courseModuleBusinessRules)
        {
            _mapper = mapper;
            _courseModuleRepository = courseModuleRepository;
            _courseModuleBusinessRules = courseModuleBusinessRules;
        }

        public async Task<DeletedCourseModuleResponse> Handle(DeleteCourseModuleCommand request, CancellationToken cancellationToken)
        {
            CourseModule? courseModule = await _courseModuleRepository.GetAsync(predicate: cm => cm.Id == request.Id, cancellationToken: cancellationToken);
            await _courseModuleBusinessRules.CourseModuleShouldExistWhenSelected(courseModule);

            await _courseModuleRepository.DeleteAsync(courseModule!);

            DeletedCourseModuleResponse response = _mapper.Map<DeletedCourseModuleResponse>(courseModule);
            return response;
        }
    }
}