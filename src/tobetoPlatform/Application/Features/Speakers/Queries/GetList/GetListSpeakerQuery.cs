using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Speakers.Queries.GetList;

public class GetListSpeakerQuery : IRequest<GetListResponse<GetListSpeakerListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSpeakerQueryHandler : IRequestHandler<GetListSpeakerQuery, GetListResponse<GetListSpeakerListItemDto>>
    {
        private readonly ISpeakerRepository _speakerRepository;
        private readonly IMapper _mapper;

        public GetListSpeakerQueryHandler(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            _speakerRepository = speakerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSpeakerListItemDto>> Handle(GetListSpeakerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Speaker> speakers = await _speakerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSpeakerListItemDto> response = _mapper.Map<GetListResponse<GetListSpeakerListItemDto>>(speakers);
            return response;
        }
    }
}