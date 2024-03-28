using Core.Application.Dtos;

namespace Application.Features.TobetoSendMessages.Queries.GetList;

public class GetListTobetoSendMessageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Subject { get; set; }
    public string? Content { get; set; }
    public string? SenderName { get; set; }
    public string? SenderEmail { get; set; }
    public string? ReceiverName { get; set; }
    public string? ReceiverEmail { get; set; }
    public DateTime? CreatedDate { get; set; }
}