using FluentValidation;

namespace Application.Features.ForeignLanguages.Commands.Create;

public class CreateForeignLanguageCommandValidator : AbstractValidator<CreateForeignLanguageCommand>
{
    public CreateForeignLanguageCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}