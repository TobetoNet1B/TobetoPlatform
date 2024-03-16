using Core.Application.Responses;

namespace Application.Features.TobetoContacts.Commands.Create;

public class CreatedTobetoContactResponse : IResponse
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public bool? IsReaded { get; set; }
}