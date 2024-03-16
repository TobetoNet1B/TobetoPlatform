using Core.Application.Dtos;

namespace Application.Features.TobetoContacts.Queries.GetList;

public class GetListTobetoContactListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public bool? IsReaded { get; set; }
}