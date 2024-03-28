using Application.Features.TobetoSendMessages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TobetoSendMessages.Queries.GetById;

public class GetByIdTobetoSendMessageQuery : IRequest<GetByIdTobetoSendMessageResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTobetoSendMessageQueryHandler : IRequestHandler<GetByIdTobetoSendMessageQuery, GetByIdTobetoSendMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITobetoSendMessageRepository _tobetoSendMessageRepository;
        private readonly TobetoSendMessageBusinessRules _tobetoSendMessageBusinessRules;

        public GetByIdTobetoSendMessageQueryHandler(IMapper mapper, ITobetoSendMessageRepository tobetoSendMessageRepository, TobetoSendMessageBusinessRules tobetoSendMessageBusinessRules)
        {
            _mapper = mapper;
            _tobetoSendMessageRepository = tobetoSendMessageRepository;
            _tobetoSendMessageBusinessRules = tobetoSendMessageBusinessRules;
        }

        public async Task<GetByIdTobetoSendMessageResponse> Handle(GetByIdTobetoSendMessageQuery request, CancellationToken cancellationToken)
        {
            TobetoSendMessage? tobetoSendMessage = await _tobetoSendMessageRepository.GetAsync(predicate: tsm => tsm.Id == request.Id, cancellationToken: cancellationToken);
            await _tobetoSendMessageBusinessRules.TobetoSendMessageShouldExistWhenSelected(tobetoSendMessage);

            GetByIdTobetoSendMessageResponse response = _mapper.Map<GetByIdTobetoSendMessageResponse>(tobetoSendMessage);
            return response;
        }
    }
}