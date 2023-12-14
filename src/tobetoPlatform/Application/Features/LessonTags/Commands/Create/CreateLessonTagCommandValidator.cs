using FluentValidation;

namespace Application.Features.LessonTags.Commands.Create;

public class CreateLessonTagCommandValidator : AbstractValidator<CreateLessonTagCommand>
{
    public CreateLessonTagCommandValidator()
    {
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.TagId).NotEmpty();
    }
}