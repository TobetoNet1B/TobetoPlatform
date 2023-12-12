using Core.Application.Dtos;

namespace Application.Features.Appeals.Queries.GetList;

public class GetListAppealListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid StudentId { get; set; }
}