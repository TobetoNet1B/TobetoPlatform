using Application.Features.CourseStudents.Constants;
using Application.Features.CourseStudents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseStudents.Commands.Delete;

public class DeleteCourseStudentCommand : IRequest<DeletedCourseStudentResponse>
{
    public Guid Id { get; set; }

    public class DeleteCourseStudentCommandHandler : IRequestHandler<DeleteCourseStudentCommand, DeletedCourseStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseStudentRepository _courseStudentRepository;
        private readonly CourseStudentBusinessRules _courseStudentBusinessRules;

        public DeleteCourseStudentCommandHandler(IMapper mapper, ICourseStudentRepository courseStudentRepository,
                                         CourseStudentBusinessRules courseStudentBusinessRules)
        {
            _mapper = mapper;
            _courseStudentRepository = courseStudentRepository;
            _courseStudentBusinessRules = courseStudentBusinessRules;
        }

        public async Task<DeletedCourseStudentResponse> Handle(DeleteCourseStudentCommand request, CancellationToken cancellationToken)
        {
            CourseStudent? courseStudent = await _courseStudentRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _courseStudentBusinessRules.CourseStudentShouldExistWhenSelected(courseStudent);

            await _courseStudentRepository.DeleteAsync(courseStudent!);

            DeletedCourseStudentResponse response = _mapper.Map<DeletedCourseStudentResponse>(courseStudent);
            return response;
        }
    }
}