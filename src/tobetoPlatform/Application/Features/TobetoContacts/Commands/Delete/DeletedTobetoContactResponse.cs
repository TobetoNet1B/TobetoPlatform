using Core.Application.Responses;

namespace Application.Features.TobetoContacts.Commands.Delete;

public class DeletedTobetoContactResponse : IResponse
{
    public Guid Id { get; set; }
}