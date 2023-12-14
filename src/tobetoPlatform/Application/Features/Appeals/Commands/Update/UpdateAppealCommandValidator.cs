using FluentValidation;

namespace Application.Features.Appeals.Commands.Update;

public class UpdateAppealCommandValidator : AbstractValidator<UpdateAppealCommand>
{
    public UpdateAppealCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}