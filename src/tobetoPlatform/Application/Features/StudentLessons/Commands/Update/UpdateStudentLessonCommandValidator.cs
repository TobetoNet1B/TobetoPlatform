using FluentValidation;

namespace Application.Features.StudentLessons.Commands.Update;

public class UpdateStudentLessonCommandValidator : AbstractValidator<UpdateStudentLessonCommand>
{
    public UpdateStudentLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.IsLiked).NotEmpty();
        RuleFor(c => c.IsWatched).NotEmpty();
    }
}