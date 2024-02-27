using FluentValidation;

namespace Application.Features.Experiences.Commands.Create;

public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
    public CreateExperienceCommandValidator()
    {
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.Sector).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}