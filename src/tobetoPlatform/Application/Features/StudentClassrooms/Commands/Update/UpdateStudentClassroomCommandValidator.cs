using FluentValidation;

namespace Application.Features.StudentClassrooms.Commands.Update;

public class UpdateStudentClassroomCommandValidator : AbstractValidator<UpdateStudentClassroomCommand>
{
    public UpdateStudentClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}