using FluentValidation;

namespace Application.Features.ModuleSetCategories.Commands.Delete;

public class DeleteModuleSetCategoryCommandValidator : AbstractValidator<DeleteModuleSetCategoryCommand>
{
    public DeleteModuleSetCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}