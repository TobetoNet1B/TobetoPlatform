using Application.Features.Lessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Lessons.Commands.Update;

public class UpdateLessonCommand : IRequest<UpdatedLessonResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string LessonUrl { get; set; }
    public string? ImgUrl { get; set; }
    public string? LessonType { get; set; }
    public int? Duration { get; set; }
    public Guid? CourseId { get; set; }
    public Guid? SpeakerId { get; set; }

    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, UpdatedLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly LessonBusinessRules _lessonBusinessRules;

        public UpdateLessonCommandHandler(IMapper mapper, ILessonRepository lessonRepository,
                                         LessonBusinessRules lessonBusinessRules)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _lessonBusinessRules = lessonBusinessRules;
        }

        public async Task<UpdatedLessonResponse> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            Lesson? lesson = await _lessonRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonBusinessRules.LessonShouldExistWhenSelected(lesson);
            lesson = _mapper.Map(request, lesson);

            await _lessonRepository.UpdateAsync(lesson!);

            UpdatedLessonResponse response = _mapper.Map<UpdatedLessonResponse>(lesson);
            return response;
        }
    }
}