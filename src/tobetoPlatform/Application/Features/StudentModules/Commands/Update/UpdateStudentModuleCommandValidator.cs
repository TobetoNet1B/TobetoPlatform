using FluentValidation;

namespace Application.Features.StudentModules.Commands.Update;

public class UpdateStudentModuleCommandValidator : AbstractValidator<UpdateStudentModuleCommand>
{
    public UpdateStudentModuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ModuleSetId).NotEmpty();
        RuleFor(c => c.TimeSpent).NotEmpty();
    }
}