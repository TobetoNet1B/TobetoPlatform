using Core.Application.Responses;

namespace Application.Features.Abilities.Commands.Create;

public class CreatedAbilityResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int StudentId { get; set; }
}