using FluentValidation;

namespace Application.Features.Lessons.Commands.Create;

public class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.LessonUrl).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();
        RuleFor(c => c.LessonType).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
    }
}