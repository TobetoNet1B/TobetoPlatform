using Application.Features.Speakers.Constants;
using Application.Features.Speakers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Speakers.Commands.Delete;

public class DeleteSpeakerCommand : IRequest<DeletedSpeakerResponse>
{
    public Guid Id { get; set; }

    public class DeleteSpeakerCommandHandler : IRequestHandler<DeleteSpeakerCommand, DeletedSpeakerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly SpeakerBusinessRules _speakerBusinessRules;

        public DeleteSpeakerCommandHandler(IMapper mapper, ISpeakerRepository speakerRepository,
                                         SpeakerBusinessRules speakerBusinessRules)
        {
            _mapper = mapper;
            _speakerRepository = speakerRepository;
            _speakerBusinessRules = speakerBusinessRules;
        }

        public async Task<DeletedSpeakerResponse> Handle(DeleteSpeakerCommand request, CancellationToken cancellationToken)
        {
            Speaker? speaker = await _speakerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _speakerBusinessRules.SpeakerShouldExistWhenSelected(speaker);

            await _speakerRepository.DeleteAsync(speaker!);

            DeletedSpeakerResponse response = _mapper.Map<DeletedSpeakerResponse>(speaker);
            return response;
        }
    }
}