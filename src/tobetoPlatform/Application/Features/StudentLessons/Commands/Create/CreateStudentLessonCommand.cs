using Application.Features.StudentLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentLessons.Commands.Create;

public class CreateStudentLessonCommand : IRequest<CreatedStudentLessonResponse>
{
    public Guid? StudentId { get; set; }
    public Guid? LessonId { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsWatched { get; set; }

    public class CreateStudentLessonCommandHandler : IRequestHandler<CreateStudentLessonCommand, CreatedStudentLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentLessonRepository _studentLessonRepository;
        private readonly StudentLessonBusinessRules _studentLessonBusinessRules;

        public CreateStudentLessonCommandHandler(IMapper mapper, IStudentLessonRepository studentLessonRepository,
                                         StudentLessonBusinessRules studentLessonBusinessRules)
        {
            _mapper = mapper;
            _studentLessonRepository = studentLessonRepository;
            _studentLessonBusinessRules = studentLessonBusinessRules;
        }

        public async Task<CreatedStudentLessonResponse> Handle(CreateStudentLessonCommand request, CancellationToken cancellationToken)
        {
            StudentLesson studentLesson = _mapper.Map<StudentLesson>(request);

            await _studentLessonRepository.AddAsync(studentLesson);

            CreatedStudentLessonResponse response = _mapper.Map<CreatedStudentLessonResponse>(studentLesson);
            return response;
        }
    }
}