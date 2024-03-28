using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TobetoSendMessages.Queries.GetList;

public class GetListTobetoSendMessageQuery : IRequest<GetListResponse<GetListTobetoSendMessageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTobetoSendMessageQueryHandler : IRequestHandler<GetListTobetoSendMessageQuery, GetListResponse<GetListTobetoSendMessageListItemDto>>
    {
        private readonly ITobetoSendMessageRepository _tobetoSendMessageRepository;
        private readonly IMapper _mapper;

        public GetListTobetoSendMessageQueryHandler(ITobetoSendMessageRepository tobetoSendMessageRepository, IMapper mapper)
        {
            _tobetoSendMessageRepository = tobetoSendMessageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTobetoSendMessageListItemDto>> Handle(GetListTobetoSendMessageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TobetoSendMessage> tobetoSendMessages = await _tobetoSendMessageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTobetoSendMessageListItemDto> response = _mapper.Map<GetListResponse<GetListTobetoSendMessageListItemDto>>(tobetoSendMessages);
            return response;
        }
    }
}