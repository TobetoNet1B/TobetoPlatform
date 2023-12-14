using FluentValidation;

namespace Application.Features.StudentModules.Commands.Delete;

public class DeleteStudentModuleCommandValidator : AbstractValidator<DeleteStudentModuleCommand>
{
    public DeleteStudentModuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}