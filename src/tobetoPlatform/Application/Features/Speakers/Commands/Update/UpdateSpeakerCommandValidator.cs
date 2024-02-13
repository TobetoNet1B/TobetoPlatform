using FluentValidation;

namespace Application.Features.Speakers.Commands.Update;

public class UpdateSpeakerCommandValidator : AbstractValidator<UpdateSpeakerCommand>
{
    public UpdateSpeakerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.About).NotEmpty();
    }
}