using FluentValidation;

namespace Application.Features.ClassroomModules.Commands.Update;

public class UpdateClassroomModuleCommandValidator : AbstractValidator<UpdateClassroomModuleCommand>
{
    public UpdateClassroomModuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
        RuleFor(c => c.ModuleSetId).NotEmpty();
        RuleFor(c => c.ClassroomStartDate).NotEmpty();
        RuleFor(c => c.ClassroomEndDate).NotEmpty();
    }
}