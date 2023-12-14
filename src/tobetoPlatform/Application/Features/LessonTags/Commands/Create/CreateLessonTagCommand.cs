using Application.Features.LessonTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonTags.Commands.Create;

public class CreateLessonTagCommand : IRequest<CreatedLessonTagResponse>
{
    public Guid LessonId { get; set; }
    public Guid TagId { get; set; }

    public class CreateLessonTagCommandHandler : IRequestHandler<CreateLessonTagCommand, CreatedLessonTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonTagRepository _lessonTagRepository;
        private readonly LessonTagBusinessRules _lessonTagBusinessRules;

        public CreateLessonTagCommandHandler(IMapper mapper, ILessonTagRepository lessonTagRepository,
                                         LessonTagBusinessRules lessonTagBusinessRules)
        {
            _mapper = mapper;
            _lessonTagRepository = lessonTagRepository;
            _lessonTagBusinessRules = lessonTagBusinessRules;
        }

        public async Task<CreatedLessonTagResponse> Handle(CreateLessonTagCommand request, CancellationToken cancellationToken)
        {
            LessonTag lessonTag = _mapper.Map<LessonTag>(request);

            await _lessonTagRepository.AddAsync(lessonTag);

            CreatedLessonTagResponse response = _mapper.Map<CreatedLessonTagResponse>(lessonTag);
            return response;
        }
    }
}