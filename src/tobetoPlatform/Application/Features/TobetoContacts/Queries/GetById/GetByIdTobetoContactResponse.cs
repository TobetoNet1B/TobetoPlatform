using Core.Application.Responses;

namespace Application.Features.TobetoContacts.Queries.GetById;

public class GetByIdTobetoContactResponse : IResponse
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public bool? IsReaded { get; set; }
}