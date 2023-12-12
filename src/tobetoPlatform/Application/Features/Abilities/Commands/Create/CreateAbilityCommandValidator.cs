using FluentValidation;

namespace Application.Features.Abilities.Commands.Create;

public class CreateAbilityCommandValidator : AbstractValidator<CreateAbilityCommand>
{
    public CreateAbilityCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}