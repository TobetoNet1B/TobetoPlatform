using FluentValidation;

namespace Application.Features.CourseCategories.Commands.Create;

public class CreateCourseCategoryCommandValidator : AbstractValidator<CreateCourseCategoryCommand>
{
    public CreateCourseCategoryCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}