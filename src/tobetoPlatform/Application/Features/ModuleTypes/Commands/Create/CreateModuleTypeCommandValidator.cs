using FluentValidation;

namespace Application.Features.ModuleTypes.Commands.Create;

public class CreateModuleTypeCommandValidator : AbstractValidator<CreateModuleTypeCommand>
{
    public CreateModuleTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}