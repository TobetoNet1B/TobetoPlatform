using FluentValidation;

namespace Application.Features.Experiences.Commands.Update;

public class UpdateExperienceCommandValidator : AbstractValidator<UpdateExperienceCommand>
{
    public UpdateExperienceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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