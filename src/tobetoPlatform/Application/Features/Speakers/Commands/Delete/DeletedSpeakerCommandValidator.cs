using FluentValidation;

namespace Application.Features.Speakers.Commands.Delete;

public class DeleteSpeakerCommandValidator : AbstractValidator<DeleteSpeakerCommand>
{
    public DeleteSpeakerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}