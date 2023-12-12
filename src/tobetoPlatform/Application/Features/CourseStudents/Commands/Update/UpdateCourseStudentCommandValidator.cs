using FluentValidation;

namespace Application.Features.CourseStudents.Commands.Update;

public class UpdateCourseStudentCommandValidator : AbstractValidator<UpdateCourseStudentCommand>
{
    public UpdateCourseStudentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}