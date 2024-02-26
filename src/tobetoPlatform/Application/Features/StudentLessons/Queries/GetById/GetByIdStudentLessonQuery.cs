using Application.Features.StudentLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentLessons.Queries.GetById;

public class GetByIdStudentLessonQuery : IRequest<List<GetByIdStudentLessonResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdStudentLessonQueryHandler : IRequestHandler<GetByIdStudentLessonQuery, List<GetByIdStudentLessonResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStudentLessonRepository _studentLessonRepository;
        private readonly StudentLessonBusinessRules _studentLessonBusinessRules;

        public GetByIdStudentLessonQueryHandler(IMapper mapper, IStudentLessonRepository studentLessonRepository, StudentLessonBusinessRules studentLessonBusinessRules)
        {
            _mapper = mapper;
            _studentLessonRepository = studentLessonRepository;
            _studentLessonBusinessRules = studentLessonBusinessRules;
        }

        public async Task<List<GetByIdStudentLessonResponse>> Handle(GetByIdStudentLessonQuery request, CancellationToken cancellationToken)
        {
            var studentLessons = await _studentLessonRepository.GetListAsync(predicate: sl => sl.StudentId == request.Id, cancellationToken: cancellationToken);
            //await _studentLessonBusinessRules.StudentLessonShouldExistWhenSelected(studentLesson);

            List<GetByIdStudentLessonResponse> response = _mapper.Map<List<GetByIdStudentLessonResponse>>(studentLessons.Items);
            return response;
        }
    }
}