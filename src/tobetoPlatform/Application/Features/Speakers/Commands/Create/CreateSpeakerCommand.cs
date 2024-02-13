using Application.Features.Speakers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Speakers.Commands.Create;

public class CreateSpeakerCommand : IRequest<CreatedSpeakerResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? About { get; set; }

    public class CreateSpeakerCommandHandler : IRequestHandler<CreateSpeakerCommand, CreatedSpeakerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly SpeakerBusinessRules _speakerBusinessRules;

        public CreateSpeakerCommandHandler(IMapper mapper, ISpeakerRepository speakerRepository,
                                         SpeakerBusinessRules speakerBusinessRules)
        {
            _mapper = mapper;
            _speakerRepository = speakerRepository;
            _speakerBusinessRules = speakerBusinessRules;
        }

        public async Task<CreatedSpeakerResponse> Handle(CreateSpeakerCommand request, CancellationToken cancellationToken)
        {
            Speaker speaker = _mapper.Map<Speaker>(request);

            await _speakerRepository.AddAsync(speaker);

            CreatedSpeakerResponse response = _mapper.Map<CreatedSpeakerResponse>(speaker);
            return response;
        }
    }
}