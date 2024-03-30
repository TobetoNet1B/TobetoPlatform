using Application.Features.TobetoSendMessages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Web;

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


        private readonly IMailService _mailService;
        private readonly MailSettings _mailSettings;

        public CreateTobetoSendMessageCommandHandler(IMapper mapper,
                                                     ITobetoSendMessageRepository tobetoSendMessageRepository,
                                                     TobetoSendMessageBusinessRules tobetoSendMessageBusinessRules,
                                                     IMailService mailService,
                                                     IConfiguration configuration)
        {
            _mapper = mapper;
            _tobetoSendMessageRepository = tobetoSendMessageRepository;
            _tobetoSendMessageBusinessRules = tobetoSendMessageBusinessRules;
            _mailService = mailService;
            const string configurationSection = "MailSettings";
            _mailSettings =
                configuration.GetSection(configurationSection).Get<MailSettings>()
                ?? throw new NullReferenceException($"\"{configurationSection}\" section cannot found in configuration.");
        }

        public async Task<CreatedTobetoSendMessageResponse> Handle(CreateTobetoSendMessageCommand request, CancellationToken cancellationToken)
        {
            request.SenderEmail = _mailSettings.SenderEmail;
            request.SenderName = _mailSettings.SenderFullName;
            TobetoSendMessage tobetoSendMessage = _mapper.Map<TobetoSendMessage>(request);


            await _tobetoSendMessageRepository.AddAsync(tobetoSendMessage);

            CreatedTobetoSendMessageResponse response = _mapper.Map<CreatedTobetoSendMessageResponse>(tobetoSendMessage);

            var toEmailList = new List<MailboxAddress> { new(name: $"{tobetoSendMessage.ReceiverName}", tobetoSendMessage.ReceiverEmail) };

            _mailService.SendMail(
            new Mail
            {
                ToList = toEmailList,
                Subject = tobetoSendMessage.Subject,
                TextBody = tobetoSendMessage.Content
            });
            return response;
        }
    }
}