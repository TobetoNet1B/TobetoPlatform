using FluentValidation;

namespace Application.Features.CourseModules.Commands.Delete;

public class DeleteCourseModuleCommandValidator : AbstractValidator<DeleteCourseModuleCommand>
{
    public DeleteCourseModuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}