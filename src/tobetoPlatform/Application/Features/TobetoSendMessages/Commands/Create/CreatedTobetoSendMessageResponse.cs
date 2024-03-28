using Core.Application.Responses;

namespace Application.Features.TobetoSendMessages.Commands.Create;

public class CreatedTobetoSendMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Subject { get; set; }
    public string? Content { get; set; }
    public string? SenderName { get; set; }
    public string? SenderEmail { get; set; }
    public string? ReceiverName { get; set; }
    public string? ReceiverEmail { get; set; }
}