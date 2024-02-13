using FluentValidation;

namespace Application.Features.Speakers.Commands.Create;

public class CreateSpeakerCommandValidator : AbstractValidator<CreateSpeakerCommand>
{
    public CreateSpeakerCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.About).NotEmpty();
    }
}