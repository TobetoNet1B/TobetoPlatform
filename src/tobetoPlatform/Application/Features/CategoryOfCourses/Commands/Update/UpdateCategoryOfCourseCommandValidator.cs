using FluentValidation;

namespace Application.Features.CategoryOfCourses.Commands.Update;

public class UpdateCategoryOfCourseCommandValidator : AbstractValidator<UpdateCategoryOfCourseCommand>
{
    public UpdateCategoryOfCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}