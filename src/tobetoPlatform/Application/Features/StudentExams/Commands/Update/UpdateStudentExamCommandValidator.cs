using FluentValidation;

namespace Application.Features.StudentExams.Commands.Update;

public class UpdateStudentExamCommandValidator : AbstractValidator<UpdateStudentExamCommand>
{
    public UpdateStudentExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.IsAttended).NotEmpty();
        RuleFor(c => c.CountOfTrue).NotEmpty();
        RuleFor(c => c.CountOfFalse).NotEmpty();
        RuleFor(c => c.CountOfEmpty).NotEmpty();
        RuleFor(c => c.Score).NotEmpty();
    }
}