using FluentValidation;

namespace Application.Features.StudentClassrooms.Commands.Create;

public class CreateStudentClassroomCommandValidator : AbstractValidator<CreateStudentClassroomCommand>
{
    public CreateStudentClassroomCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}