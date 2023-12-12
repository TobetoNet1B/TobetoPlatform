using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseCommand : IRequest<UpdatedCourseResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? CourseTitle { get; set; }
    public string? Description { get; set; }
    public int? CourseLevel { get; set; }
    public string? ImgUrl { get; set; }
    public string SoftwareLanguage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? EstimatedTime { get; set; }
    public int? TimeSpent { get; set; }
    public int? Duration { get; set; }
    public string ActivityStatus { get; set; }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, UpdatedCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public UpdateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository,
                                         CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<UpdatedCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _courseBusinessRules.CourseShouldExistWhenSelected(course);
            course = _mapper.Map(request, course);

            await _courseRepository.UpdateAsync(course!);

            UpdatedCourseResponse response = _mapper.Map<UpdatedCourseResponse>(course);
            return response;
        }
    }
}