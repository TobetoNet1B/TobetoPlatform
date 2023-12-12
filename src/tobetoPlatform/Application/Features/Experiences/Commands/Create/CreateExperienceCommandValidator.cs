using FluentValidation;

namespace Application.Features.Experiences.Commands.Create;

public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
    public CreateExperienceCommandValidator()
    {
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.Sector).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.IsContinueJob).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}