using Core.Application.Responses;

namespace Application.Features.TobetoContacts.Commands.Update;

public class UpdatedTobetoContactResponse : IResponse
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public bool? IsReaded { get; set; }
}