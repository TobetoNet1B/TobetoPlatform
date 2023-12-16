using FluentValidation;

namespace Application.Features.StudentForeignLanguages.Commands.Update;

public class UpdateStudentForeignLanguageCommandValidator : AbstractValidator<UpdateStudentForeignLanguageCommand>
{
    public UpdateStudentForeignLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ForeignLanguageId).NotEmpty();
        RuleFor(c => c.ForeignLanguageLevelId).NotEmpty();
    }
}