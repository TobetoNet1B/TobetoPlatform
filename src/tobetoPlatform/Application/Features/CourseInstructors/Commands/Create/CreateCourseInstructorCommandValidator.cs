using FluentValidation;

namespace Application.Features.CourseInstructors.Commands.Create;

public class CreateCourseInstructorCommandValidator : AbstractValidator<CreateCourseInstructorCommand>
{
    public CreateCourseInstructorCommandValidator()
    {
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
    }
}