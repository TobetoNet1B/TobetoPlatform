using FluentValidation;

namespace Application.Features.StudentForeignLanguages.Commands.Create;

public class CreateStudentForeignLanguageCommandValidator : AbstractValidator<CreateStudentForeignLanguageCommand>
{
    public CreateStudentForeignLanguageCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ForeignLanguageId).NotEmpty();
        RuleFor(c => c.ForeignLanguageLevelId).NotEmpty();
    }
}