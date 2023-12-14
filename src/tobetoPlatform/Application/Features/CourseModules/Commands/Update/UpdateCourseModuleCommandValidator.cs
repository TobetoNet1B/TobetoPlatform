using FluentValidation;

namespace Application.Features.CourseModules.Commands.Update;

public class UpdateCourseModuleCommandValidator : AbstractValidator<UpdateCourseModuleCommand>
{
    public UpdateCourseModuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.ModuleId).NotEmpty();
    }
}