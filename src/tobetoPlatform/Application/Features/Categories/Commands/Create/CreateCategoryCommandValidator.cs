using FluentValidation;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
        RuleFor(c => c.ParentId).NotEmpty();
        RuleFor(c => c.OrderNo).NotEmpty();
    }
}