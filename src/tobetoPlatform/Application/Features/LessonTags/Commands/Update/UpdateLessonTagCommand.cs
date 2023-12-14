using Application.Features.LessonTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonTags.Commands.Update;

public class UpdateLessonTagCommand : IRequest<UpdatedLessonTagResponse>
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid TagId { get; set; }

    public class UpdateLessonTagCommandHandler : IRequestHandler<UpdateLessonTagCommand, UpdatedLessonTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonTagRepository _lessonTagRepository;
        private readonly LessonTagBusinessRules _lessonTagBusinessRules;

        public UpdateLessonTagCommandHandler(IMapper mapper, ILessonTagRepository lessonTagRepository,
                                         LessonTagBusinessRules lessonTagBusinessRules)
        {
            _mapper = mapper;
            _lessonTagRepository = lessonTagRepository;
            _lessonTagBusinessRules = lessonTagBusinessRules;
        }

        public async Task<UpdatedLessonTagResponse> Handle(UpdateLessonTagCommand request, CancellationToken cancellationToken)
        {
            LessonTag? lessonTag = await _lessonTagRepository.GetAsync(predicate: lt => lt.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonTagBusinessRules.LessonTagShouldExistWhenSelected(lessonTag);
            lessonTag = _mapper.Map(request, lessonTag);

            await _lessonTagRepository.UpdateAsync(lessonTag!);

            UpdatedLessonTagResponse response = _mapper.Map<UpdatedLessonTagResponse>(lessonTag);
            return response;
        }
    }
}