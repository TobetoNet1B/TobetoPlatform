using FluentValidation;

namespace Application.Features.ClassroomModules.Commands.Delete;

public class DeleteClassroomModuleCommandValidator : AbstractValidator<DeleteClassroomModuleCommand>
{
    public DeleteClassroomModuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}