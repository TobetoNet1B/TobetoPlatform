using FluentValidation;

namespace Application.Features.ForeignLanguages.Commands.Update;

public class UpdateForeignLanguageCommandValidator : AbstractValidator<UpdateForeignLanguageCommand>
{
    public UpdateForeignLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}