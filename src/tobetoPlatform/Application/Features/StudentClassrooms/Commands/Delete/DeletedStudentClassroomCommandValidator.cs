using FluentValidation;

namespace Application.Features.StudentClassrooms.Commands.Delete;

public class DeleteStudentClassroomCommandValidator : AbstractValidator<DeleteStudentClassroomCommand>
{
    public DeleteStudentClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}