using FluentValidation;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(c => c.IdentityNumber).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.About).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();
    }
}