using FluentValidation;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
{
    public CreateInstructorCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}