using Core.Application.Responses;

namespace Application.Features.Abilities.Queries.GetById;

public class GetByIdAbilityResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid StudentId { get; set; }
}