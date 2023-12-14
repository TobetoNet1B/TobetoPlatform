using FluentValidation;

namespace Application.Features.CourseModules.Commands.Create;

public class CreateCourseModuleCommandValidator : AbstractValidator<CreateCourseModuleCommand>
{
    public CreateCourseModuleCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.ModuleId).NotEmpty();
    }
}