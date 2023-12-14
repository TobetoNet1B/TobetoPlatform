using Application.Features.LessonTags.Constants;
using Application.Features.LessonTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonTags.Commands.Delete;

public class DeleteLessonTagCommand : IRequest<DeletedLessonTagResponse>
{
    public Guid Id { get; set; }

    public class DeleteLessonTagCommandHandler : IRequestHandler<DeleteLessonTagCommand, DeletedLessonTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonTagRepository _lessonTagRepository;
        private readonly LessonTagBusinessRules _lessonTagBusinessRules;

        public DeleteLessonTagCommandHandler(IMapper mapper, ILessonTagRepository lessonTagRepository,
                                         LessonTagBusinessRules lessonTagBusinessRules)
        {
            _mapper = mapper;
            _lessonTagRepository = lessonTagRepository;
            _lessonTagBusinessRules = lessonTagBusinessRules;
        }

        public async Task<DeletedLessonTagResponse> Handle(DeleteLessonTagCommand request, CancellationToken cancellationToken)
        {
            LessonTag? lessonTag = await _lessonTagRepository.GetAsync(predicate: lt => lt.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonTagBusinessRules.LessonTagShouldExistWhenSelected(lessonTag);

            await _lessonTagRepository.DeleteAsync(lessonTag!);

            DeletedLessonTagResponse response = _mapper.Map<DeletedLessonTagResponse>(lessonTag);
            return response;
        }
    }
}