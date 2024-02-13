using FluentValidation;

namespace Application.Features.CategoryOfCourses.Commands.Delete;

public class DeleteCategoryOfCourseCommandValidator : AbstractValidator<DeleteCategoryOfCourseCommand>
{
    public DeleteCategoryOfCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}