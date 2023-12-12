using FluentValidation;

namespace Application.Features.Appeals.Commands.Create;

public class CreateAppealCommandValidator : AbstractValidator<CreateAppealCommand>
{
    public CreateAppealCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}