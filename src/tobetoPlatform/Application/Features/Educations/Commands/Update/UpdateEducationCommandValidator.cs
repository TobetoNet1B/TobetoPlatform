using FluentValidation;

namespace Application.Features.Educations.Commands.Update;

public class UpdateEducationCommandValidator : AbstractValidator<UpdateEducationCommand>
{
    public UpdateEducationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.University).NotEmpty();
        RuleFor(c => c.Department).NotEmpty();
        RuleFor(c => c.Graduation).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.IsContinueUniversity).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}