using FluentValidation;

namespace Application.Features.LessonTags.Commands.Update;

public class UpdateLessonTagCommandValidator : AbstractValidator<UpdateLessonTagCommand>
{
    public UpdateLessonTagCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.TagId).NotEmpty();
    }
}