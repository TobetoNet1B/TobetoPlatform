using Application.Features.CourseStudents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseStudents.Queries.GetById;

public class GetByIdCourseStudentQuery : IRequest<GetByIdCourseStudentResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCourseStudentQueryHandler : IRequestHandler<GetByIdCourseStudentQuery, GetByIdCourseStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseStudentRepository _courseStudentRepository;
        private readonly CourseStudentBusinessRules _courseStudentBusinessRules;

        public GetByIdCourseStudentQueryHandler(IMapper mapper, ICourseStudentRepository courseStudentRepository, CourseStudentBusinessRules courseStudentBusinessRules)
        {
            _mapper = mapper;
            _courseStudentRepository = courseStudentRepository;
            _courseStudentBusinessRules = courseStudentBusinessRules;
        }

        public async Task<GetByIdCourseStudentResponse> Handle(GetByIdCourseStudentQuery request, CancellationToken cancellationToken)
        {
            CourseStudent? courseStudent = await _courseStudentRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _courseStudentBusinessRules.CourseStudentShouldExistWhenSelected(courseStudent);

            GetByIdCourseStudentResponse response = _mapper.Map<GetByIdCourseStudentResponse>(courseStudent);
            return response;
        }
    }
}