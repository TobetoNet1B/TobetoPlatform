using FluentValidation;

namespace Application.Features.StudentLessons.Commands.Create;

public class CreateStudentLessonCommandValidator : AbstractValidator<CreateStudentLessonCommand>
{
    public CreateStudentLessonCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.IsLiked).NotEmpty();
        RuleFor(c => c.IsWatched).NotEmpty();
    }
}