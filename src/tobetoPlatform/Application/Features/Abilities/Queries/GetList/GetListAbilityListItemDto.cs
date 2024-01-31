using Core.Application.Dtos;

namespace Application.Features.Abilities.Queries.GetList;

public class GetListAbilityListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid StudentId { get; set; }
}