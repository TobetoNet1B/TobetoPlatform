using FluentValidation;

namespace Application.Features.Educations.Commands.Create;

public class CreateEducationCommandValidator : AbstractValidator<CreateEducationCommand>
{
    public CreateEducationCommandValidator()
    {
        RuleFor(c => c.University).NotEmpty();
        RuleFor(c => c.Department).NotEmpty();
        RuleFor(c => c.Graduation).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        //RuleFor(c => c.EndDate).NotEmpty();
        //RuleFor(c => c.IsContinueUniversity).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}