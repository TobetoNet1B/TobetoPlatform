using FluentValidation;

namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CourseTitle).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.CourseLevel).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.EstimatedTime).NotEmpty();
        RuleFor(c => c.ActivityStatus).NotEmpty();
    }
}