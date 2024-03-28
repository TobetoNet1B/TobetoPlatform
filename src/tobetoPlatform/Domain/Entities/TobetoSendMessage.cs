using Core.Persistence.Repositories;

namespace Domain.Entities;
public class TobetoSendMessage : Entity<Guid>
{
    public string? Subject { get; set; }
    public string? Content { get; set; }
    public string? SenderName { get; set; }
    public string? SenderEmail { get; set; }
    public string? ReceiverName { get; set; }
    public string? ReceiverEmail { get; set; }

    public TobetoSendMessage()
    {
    }

    public TobetoSendMessage(Guid id, string? subject, string? content, string? senderName, string? senderEmail, string? receiverName, string? receiverEmail) : base(id)
    {
        Subject = subject;
        Content = content;
        SenderName = senderName;
        SenderEmail = senderEmail;
        ReceiverName = receiverName;
        ReceiverEmail = receiverEmail;
    }
}
