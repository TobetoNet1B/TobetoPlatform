using Application.Features.TobetoSendMessages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TobetoSendMessages.Commands.Create;

public class CreateTobetoSendMessageCommand : IRequest<CreatedTobetoSendMessageResponse>
{
    public string? Subject { get; set; }
    public string? Content { get; set; }
    public string? SenderName { get; set; }
    public string? SenderEmail { get; set; }
    public string? ReceiverName { get; set; }
    public string? ReceiverEmail { get; set; }

    public class CreateTobetoSendMessageCommandHandler : IRequestHandler<CreateTobetoSendMessageCommand, CreatedTobetoSendMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITobetoSendMessageRepository _tobetoSendMessageRepository;
        private readonly TobetoSendMessageBusinessRules _tobetoSendMessageBusinessRules;

        public CreateTobetoSendMessageCommandHandler(IMapper mapper, ITobetoSendMessageRepository tobetoSendMessageRepository,
                                         TobetoSendMessageBusinessRules tobetoSendMessageBusinessRules)
        {
            _mapper = mapper;
            _tobetoSendMessageRepository = tobetoSendMessageRepository;
            _tobetoSendMessageBusinessRules = tobetoSendMessageBusinessRules;
        }

        public async Task<CreatedTobetoSendMessageResponse> Handle(CreateTobetoSendMessageCommand request, CancellationToken cancellationToken)
        {
            TobetoSendMessage tobetoSendMessage = _mapper.Map<TobetoSendMessage>(request);

            await _tobetoSendMessageRepository.AddAsync(tobetoSendMessage);

            CreatedTobetoSendMessageResponse response = _mapper.Map<CreatedTobetoSendMessageResponse>(tobetoSendMessage);
            return response;
        }
    }
}