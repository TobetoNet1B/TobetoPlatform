using FluentValidation;

namespace Application.Features.CategoryOfModuleSets.Commands.Update;

public class UpdateCategoryOfModuleSetCommandValidator : AbstractValidator<UpdateCategoryOfModuleSetCommand>
{
    public UpdateCategoryOfModuleSetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}