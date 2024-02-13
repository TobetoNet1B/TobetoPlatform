using Application.Features.Speakers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Speakers.Queries.GetById;

public class GetByIdSpeakerQuery : IRequest<GetByIdSpeakerResponse>
{
    public Guid Id { get; set; }

    public class GetByIdSpeakerQueryHandler : IRequestHandler<GetByIdSpeakerQuery, GetByIdSpeakerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly SpeakerBusinessRules _speakerBusinessRules;

        public GetByIdSpeakerQueryHandler(IMapper mapper, ISpeakerRepository speakerRepository, SpeakerBusinessRules speakerBusinessRules)
        {
            _mapper = mapper;
            _speakerRepository = speakerRepository;
            _speakerBusinessRules = speakerBusinessRules;
        }

        public async Task<GetByIdSpeakerResponse> Handle(GetByIdSpeakerQuery request, CancellationToken cancellationToken)
        {
            Speaker? speaker = await _speakerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _speakerBusinessRules.SpeakerShouldExistWhenSelected(speaker);

            GetByIdSpeakerResponse response = _mapper.Map<GetByIdSpeakerResponse>(speaker);
            return response;
        }
    }
}