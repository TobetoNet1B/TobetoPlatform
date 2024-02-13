using FluentValidation;

namespace Application.Features.CategoryOfModuleSets.Commands.Create;

public class CreateCategoryOfModuleSetCommandValidator : AbstractValidator<CreateCategoryOfModuleSetCommand>
{
    public CreateCategoryOfModuleSetCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}