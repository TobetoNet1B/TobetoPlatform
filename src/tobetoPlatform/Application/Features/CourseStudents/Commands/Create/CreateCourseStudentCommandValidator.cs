using FluentValidation;

namespace Application.Features.CourseStudents.Commands.Create;

public class CreateCourseStudentCommandValidator : AbstractValidator<CreateCourseStudentCommand>
{
    public CreateCourseStudentCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}