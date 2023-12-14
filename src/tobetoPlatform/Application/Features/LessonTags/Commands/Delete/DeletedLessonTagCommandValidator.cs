using FluentValidation;

namespace Application.Features.LessonTags.Commands.Delete;

public class DeleteLessonTagCommandValidator : AbstractValidator<DeleteLessonTagCommand>
{
    public DeleteLessonTagCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}