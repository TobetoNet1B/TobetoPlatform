using FluentValidation;

namespace Application.Features.TobetoSendMessages.Commands.Create;

public class CreateTobetoSendMessageCommandValidator : AbstractValidator<CreateTobetoSendMessageCommand>
{
    public CreateTobetoSendMessageCommandValidator()
    {
        RuleFor(c => c.Subject).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        //RuleFor(c => c.SenderName).NotEmpty();
        //RuleFor(c => c.SenderEmail).NotEmpty();
        RuleFor(c => c.ReceiverName).NotEmpty();
        RuleFor(c => c.ReceiverEmail).NotEmpty();
    }
}