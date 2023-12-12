using Application.Features.CourseStudents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseStudents.Commands.Create;

public class CreateCourseStudentCommand : IRequest<CreatedCourseStudentResponse>
{
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }

    public class CreateCourseStudentCommandHandler : IRequestHandler<CreateCourseStudentCommand, CreatedCourseStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseStudentRepository _courseStudentRepository;
        private readonly CourseStudentBusinessRules _courseStudentBusinessRules;

        public CreateCourseStudentCommandHandler(IMapper mapper, ICourseStudentRepository courseStudentRepository,
                                         CourseStudentBusinessRules courseStudentBusinessRules)
        {
            _mapper = mapper;
            _courseStudentRepository = courseStudentRepository;
            _courseStudentBusinessRules = courseStudentBusinessRules;
        }

        public async Task<CreatedCourseStudentResponse> Handle(CreateCourseStudentCommand request, CancellationToken cancellationToken)
        {
            CourseStudent courseStudent = _mapper.Map<CourseStudent>(request);

            await _courseStudentRepository.AddAsync(courseStudent);

            CreatedCourseStudentResponse response = _mapper.Map<CreatedCourseStudentResponse>(courseStudent);
            return response;
        }
    }
}