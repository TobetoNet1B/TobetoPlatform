using FluentValidation;

namespace Application.Features.ModuleSetCategories.Commands.Update;

public class UpdateModuleSetCategoryCommandValidator : AbstractValidator<UpdateModuleSetCategoryCommand>
{
    public UpdateModuleSetCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ModuleSetId).NotEmpty();
        RuleFor(c => c.CategoryOfModuleSetId).NotEmpty();
    }
}