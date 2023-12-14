using FluentValidation;

namespace Application.Features.SoftwareLanguages.Commands.Create;

public class CreateSoftwareLanguageCommandValidator : AbstractValidator<CreateSoftwareLanguageCommand>
{
    public CreateSoftwareLanguageCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}