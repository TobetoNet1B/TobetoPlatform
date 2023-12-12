using FluentValidation;

namespace Application.Features.StudentExams.Commands.Create;

public class CreateStudentExamCommandValidator : AbstractValidator<CreateStudentExamCommand>
{
    public CreateStudentExamCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
    }
}