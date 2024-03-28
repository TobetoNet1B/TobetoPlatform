using Core.Application.Responses;

namespace Application.Features.TobetoSendMessages.Commands.Delete;

public class DeletedTobetoSendMessageResponse : IResponse
{
    public Guid Id { get; set; }
}