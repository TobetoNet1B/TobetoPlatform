using FluentValidation;

namespace Application.Features.TobetoSendMessages.Commands.Delete;

public class DeleteTobetoSendMessageCommandValidator : AbstractValidator<DeleteTobetoSendMessageCommand>
{
    public DeleteTobetoSendMessageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}