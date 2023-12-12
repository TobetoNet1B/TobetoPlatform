using FluentValidation;

namespace Application.Features.CourseCategories.Commands.Update;

public class UpdateCourseCategoryCommandValidator : AbstractValidator<UpdateCourseCategoryCommand>
{
    public UpdateCourseCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}