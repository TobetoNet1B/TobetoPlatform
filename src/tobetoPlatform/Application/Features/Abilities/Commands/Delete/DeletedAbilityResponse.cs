using Core.Application.Responses;

namespace Application.Features.Abilities.Commands.Delete;

public class DeletedAbilityResponse : IResponse
{
    public Guid Id { get; set; }
}