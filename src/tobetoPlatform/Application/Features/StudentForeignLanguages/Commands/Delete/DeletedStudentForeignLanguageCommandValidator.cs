using FluentValidation;

namespace Application.Features.StudentForeignLanguages.Commands.Delete;

public class DeleteStudentForeignLanguageCommandValidator : AbstractValidator<DeleteStudentForeignLanguageCommand>
{
    public DeleteStudentForeignLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}