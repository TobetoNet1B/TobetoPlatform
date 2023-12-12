using FluentValidation;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CourseTitle).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.CourseLevel).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();
        RuleFor(c => c.SoftwareLanguage).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.EstimatedTime).NotEmpty();
        RuleFor(c => c.TimeSpent).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.ActivityStatus).NotEmpty();
    }
}