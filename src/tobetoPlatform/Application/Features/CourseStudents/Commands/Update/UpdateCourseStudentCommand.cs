using Application.Features.CourseStudents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseStudents.Commands.Update;

public class UpdateCourseStudentCommand : IRequest<UpdatedCourseStudentResponse>
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }

    public class UpdateCourseStudentCommandHandler : IRequestHandler<UpdateCourseStudentCommand, UpdatedCourseStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseStudentRepository _courseStudentRepository;
        private readonly CourseStudentBusinessRules _courseStudentBusinessRules;

        public UpdateCourseStudentCommandHandler(IMapper mapper, ICourseStudentRepository courseStudentRepository,
                                         CourseStudentBusinessRules courseStudentBusinessRules)
        {
            _mapper = mapper;
            _courseStudentRepository = courseStudentRepository;
            _courseStudentBusinessRules = courseStudentBusinessRules;
        }

        public async Task<UpdatedCourseStudentResponse> Handle(UpdateCourseStudentCommand request, CancellationToken cancellationToken)
        {
            CourseStudent? courseStudent = await _courseStudentRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _courseStudentBusinessRules.CourseStudentShouldExistWhenSelected(courseStudent);
            courseStudent = _mapper.Map(request, courseStudent);

            await _courseStudentRepository.UpdateAsync(courseStudent!);

            UpdatedCourseStudentResponse response = _mapper.Map<UpdatedCourseStudentResponse>(courseStudent);
            return response;
        }
    }
}