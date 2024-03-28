using Application.Features.TobetoSendMessages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TobetoSendMessages.Commands.Update;

public class UpdateTobetoSendMessageCommand : IRequest<UpdatedTobetoSendMessageResponse>
{
    public Guid Id { get; set; }
    public string? Subject { get; set; }
    public string? Content { get; set; }
    public string? SenderName { get; set; }
    public string? SenderEmail { get; set; }
    public string? ReceiverName { get; set; }
    public string? ReceiverEmail { get; set; }

    public class UpdateTobetoSendMessageCommandHandler : IRequestHandler<UpdateTobetoSendMessageCommand, UpdatedTobetoSendMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITobetoSendMessageRepository _tobetoSendMessageRepository;
        private readonly TobetoSendMessageBusinessRules _tobetoSendMessageBusinessRules;

        public UpdateTobetoSendMessageCommandHandler(IMapper mapper, ITobetoSendMessageRepository tobetoSendMessageRepository,
                                         TobetoSendMessageBusinessRules tobetoSendMessageBusinessRules)
        {
            _mapper = mapper;
            _tobetoSendMessageRepository = tobetoSendMessageRepository;
            _tobetoSendMessageBusinessRules = tobetoSendMessageBusinessRules;
        }

        public async Task<UpdatedTobetoSendMessageResponse> Handle(UpdateTobetoSendMessageCommand request, CancellationToken cancellationToken)
        {
            TobetoSendMessage? tobetoSendMessage = await _tobetoSendMessageRepository.GetAsync(predicate: tsm => tsm.Id == request.Id, cancellationToken: cancellationToken);
            await _tobetoSendMessageBusinessRules.TobetoSendMessageShouldExistWhenSelected(tobetoSendMessage);
            tobetoSendMessage = _mapper.Map(request, tobetoSendMessage);

            await _tobetoSendMessageRepository.UpdateAsync(tobetoSendMessage!);

            UpdatedTobetoSendMessageResponse response = _mapper.Map<UpdatedTobetoSendMessageResponse>(tobetoSendMessage);
            return response;
        }
    }
}