using FluentValidation;

namespace Application.Features.StudentModules.Commands.Create;

public class CreateStudentModuleCommandValidator : AbstractValidator<CreateStudentModuleCommand>
{
    public CreateStudentModuleCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ModuleSetId).NotEmpty();
        RuleFor(c => c.TimeSpent).NotEmpty();
    }
}