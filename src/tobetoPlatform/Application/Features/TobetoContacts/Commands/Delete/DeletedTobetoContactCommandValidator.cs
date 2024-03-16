using FluentValidation;

namespace Application.Features.TobetoContacts.Commands.Delete;

public class DeleteTobetoContactCommandValidator : AbstractValidator<DeleteTobetoContactCommand>
{
    public DeleteTobetoContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}