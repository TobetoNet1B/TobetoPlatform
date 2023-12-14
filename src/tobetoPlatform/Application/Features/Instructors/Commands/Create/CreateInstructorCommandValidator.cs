using FluentValidation;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
{
    public CreateInstructorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}