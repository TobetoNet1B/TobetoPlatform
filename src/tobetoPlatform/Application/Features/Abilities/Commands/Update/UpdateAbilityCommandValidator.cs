using FluentValidation;

namespace Application.Features.Abilities.Commands.Update;

public class UpdateAbilityCommandValidator : AbstractValidator<UpdateAbilityCommand>
{
    public UpdateAbilityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}