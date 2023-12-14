using FluentValidation;

namespace Application.Features.Modules.Commands.Delete;

public class DeleteModuleCommandValidator : AbstractValidator<DeleteModuleCommand>
{
    public DeleteModuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}