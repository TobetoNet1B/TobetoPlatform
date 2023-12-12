using FluentValidation;

namespace Application.Features.Abilities.Commands.Delete;

public class DeleteAbilityCommandValidator : AbstractValidator<DeleteAbilityCommand>
{
    public DeleteAbilityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}