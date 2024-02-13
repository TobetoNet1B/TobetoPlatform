using FluentValidation;

namespace Application.Features.CategoryOfCourses.Commands.Create;

public class CreateCategoryOfCourseCommandValidator : AbstractValidator<CreateCategoryOfCourseCommand>
{
    public CreateCategoryOfCourseCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}