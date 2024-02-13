using FluentValidation;

namespace Application.Features.ModuleSetCategories.Commands.Create;

public class CreateModuleSetCategoryCommandValidator : AbstractValidator<CreateModuleSetCategoryCommand>
{
    public CreateModuleSetCategoryCommandValidator()
    {
        RuleFor(c => c.ModuleSetId).NotEmpty();
        RuleFor(c => c.CategoryOfModuleSetId).NotEmpty();
    }
}