using FluentValidation;

namespace Application.Features.ModuleTypes.Commands.Update;

public class UpdateModuleTypeCommandValidator : AbstractValidator<UpdateModuleTypeCommand>
{
    public UpdateModuleTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}