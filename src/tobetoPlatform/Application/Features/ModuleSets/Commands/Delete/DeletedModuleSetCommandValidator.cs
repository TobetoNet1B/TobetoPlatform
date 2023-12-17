using FluentValidation;

namespace Application.Features.ModuleSets.Commands.Delete;

public class DeleteModuleSetCommandValidator : AbstractValidator<DeleteModuleSetCommand>
{
    public DeleteModuleSetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}