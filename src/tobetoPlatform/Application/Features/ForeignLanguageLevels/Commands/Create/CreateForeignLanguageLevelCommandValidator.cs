using FluentValidation;

namespace Application.Features.ForeignLanguageLevels.Commands.Create;

public class CreateForeignLanguageLevelCommandValidator : AbstractValidator<CreateForeignLanguageLevelCommand>
{
    public CreateForeignLanguageLevelCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ForeignLanguageId).NotEmpty();
    }
}