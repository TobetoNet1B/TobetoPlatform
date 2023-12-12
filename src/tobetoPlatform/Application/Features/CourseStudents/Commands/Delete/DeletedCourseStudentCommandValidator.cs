using FluentValidation;

namespace Application.Features.CourseStudents.Commands.Delete;

public class DeleteCourseStudentCommandValidator : AbstractValidator<DeleteCourseStudentCommand>
{
    public DeleteCourseStudentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}