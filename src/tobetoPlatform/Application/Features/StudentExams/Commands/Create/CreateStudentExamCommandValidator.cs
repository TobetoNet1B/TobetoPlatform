using FluentValidation;

namespace Application.Features.StudentExams.Commands.Create;

public class CreateStudentExamCommandValidator : AbstractValidator<CreateStudentExamCommand>
{
    public CreateStudentExamCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.IsAttended).NotEmpty();
        RuleFor(c => c.CountOfTrue).NotEmpty();
        RuleFor(c => c.CountOfFalse).NotEmpty();
        RuleFor(c => c.CountOfEmpty).NotEmpty();
        RuleFor(c => c.Score).NotEmpty();
    }
}