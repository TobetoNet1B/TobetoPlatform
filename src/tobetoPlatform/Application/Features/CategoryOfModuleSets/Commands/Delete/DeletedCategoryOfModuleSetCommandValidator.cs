using FluentValidation;

namespace Application.Features.CategoryOfModuleSets.Commands.Delete;

public class DeleteCategoryOfModuleSetCommandValidator : AbstractValidator<DeleteCategoryOfModuleSetCommand>
{
    public DeleteCategoryOfModuleSetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}