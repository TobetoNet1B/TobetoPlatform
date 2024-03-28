using FluentValidation;

namespace Application.Features.TobetoSendMessages.Commands.Update;

public class UpdateTobetoSendMessageCommandValidator : AbstractValidator<UpdateTobetoSendMessageCommand>
{
    public UpdateTobetoSendMessageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Subject).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.SenderName).NotEmpty();
        RuleFor(c => c.SenderEmail).NotEmpty();
        RuleFor(c => c.ReceiverName).NotEmpty();
        RuleFor(c => c.ReceiverEmail).NotEmpty();
    }
}