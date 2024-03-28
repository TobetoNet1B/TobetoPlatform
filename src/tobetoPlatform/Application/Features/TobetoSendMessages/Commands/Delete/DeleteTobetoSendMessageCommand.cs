using Application.Features.TobetoSendMessages.Constants;
using Application.Features.TobetoSendMessages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TobetoSendMessages.Commands.Delete;

public class DeleteTobetoSendMessageCommand : IRequest<DeletedTobetoSendMessageResponse>
{
    public Guid Id { get; set; }

    public class DeleteTobetoSendMessageCommandHandler : IRequestHandler<DeleteTobetoSendMessageCommand, DeletedTobetoSendMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITobetoSendMessageRepository _tobetoSendMessageRepository;
        private readonly TobetoSendMessageBusinessRules _tobetoSendMessageBusinessRules;

        public DeleteTobetoSendMessageCommandHandler(IMapper mapper, ITobetoSendMessageRepository tobetoSendMessageRepository,
                                         TobetoSendMessageBusinessRules tobetoSendMessageBusinessRules)
        {
            _mapper = mapper;
            _tobetoSendMessageRepository = tobetoSendMessageRepository;
            _tobetoSendMessageBusinessRules = tobetoSendMessageBusinessRules;
        }

        public async Task<DeletedTobetoSendMessageResponse> Handle(DeleteTobetoSendMessageCommand request, CancellationToken cancellationToken)
        {
            TobetoSendMessage? tobetoSendMessage = await _tobetoSendMessageRepository.GetAsync(predicate: tsm => tsm.Id == request.Id, cancellationToken: cancellationToken);
            await _tobetoSendMessageBusinessRules.TobetoSendMessageShouldExistWhenSelected(tobetoSendMessage);

            await _tobetoSendMessageRepository.DeleteAsync(tobetoSendMessage!);

            DeletedTobetoSendMessageResponse response = _mapper.Map<DeletedTobetoSendMessageResponse>(tobetoSendMessage);
            return response;
        }
    }
}