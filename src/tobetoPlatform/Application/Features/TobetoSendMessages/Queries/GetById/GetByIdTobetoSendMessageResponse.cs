using Core.Application.Responses;

namespace Application.Features.TobetoSendMessages.Queries.GetById;

public class GetByIdTobetoSendMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Subject { get; set; }
    public string? Content { get; set; }
    public string? SenderName { get; set; }
    public string? SenderEmail { get; set; }
    public string? ReceiverName { get; set; }
    public string? ReceiverEmail { get; set; }
}