using FluentValidation;

namespace Application.Features.ForeignLanguages.Commands.Update;

public class UpdateForeignLanguageCommandValidator : AbstractValidator<UpdateForeignLanguageCommand>
{
    public UpdateForeignLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ForeignLanguageLevelId).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}