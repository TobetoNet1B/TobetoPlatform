using FluentValidation;

namespace Application.Features.ModuleTypes.Commands.Delete;

public class DeleteModuleTypeCommandValidator : AbstractValidator<DeleteModuleTypeCommand>
{
    public DeleteModuleTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}