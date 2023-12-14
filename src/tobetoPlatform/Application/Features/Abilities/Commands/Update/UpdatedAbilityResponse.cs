using Core.Application.Responses;

namespace Application.Features.Abilities.Commands.Update;

public class UpdatedAbilityResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int StudentId { get; set; }
}