using FluentValidation;

namespace Application.Features.ClassroomModules.Commands.Create;

public class CreateClassroomModuleCommandValidator : AbstractValidator<CreateClassroomModuleCommand>
{
    public CreateClassroomModuleCommandValidator()
    {
        RuleFor(c => c.ClassroomId).NotEmpty();
        RuleFor(c => c.ModuleSetId).NotEmpty();
        RuleFor(c => c.ClassroomStartDate).NotEmpty();
        RuleFor(c => c.ClassroomEndDate).NotEmpty();
    }
}