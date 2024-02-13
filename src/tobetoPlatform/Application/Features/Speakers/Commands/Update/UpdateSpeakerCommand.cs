using Application.Features.Speakers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Speakers.Commands.Update;

public class UpdateSpeakerCommand : IRequest<UpdatedSpeakerResponse>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? About { get; set; }

    public class UpdateSpeakerCommandHandler : IRequestHandler<UpdateSpeakerCommand, UpdatedSpeakerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly SpeakerBusinessRules _speakerBusinessRules;

        public UpdateSpeakerCommandHandler(IMapper mapper, ISpeakerRepository speakerRepository,
                                         SpeakerBusinessRules speakerBusinessRules)
        {
            _mapper = mapper;
            _speakerRepository = speakerRepository;
            _speakerBusinessRules = speakerBusinessRules;
        }

        public async Task<UpdatedSpeakerResponse> Handle(UpdateSpeakerCommand request, CancellationToken cancellationToken)
        {
            Speaker? speaker = await _speakerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _speakerBusinessRules.SpeakerShouldExistWhenSelected(speaker);
            speaker = _mapper.Map(request, speaker);

            await _speakerRepository.UpdateAsync(speaker!);

            UpdatedSpeakerResponse response = _mapper.Map<UpdatedSpeakerResponse>(speaker);
            return response;
        }
    }
}