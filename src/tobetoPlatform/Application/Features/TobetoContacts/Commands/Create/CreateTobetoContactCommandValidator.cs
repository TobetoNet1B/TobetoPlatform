using FluentValidation;

namespace Application.Features.TobetoContacts.Commands.Create;

public class CreateTobetoContactCommandValidator : AbstractValidator<CreateTobetoContactCommand>
{
    public CreateTobetoContactCommandValidator()
    {
        RuleFor(c => c.FullName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.Message).NotEmpty().MinimumLength(4);
        //RuleFor(c => c.IsReaded).NotEmpty();
    }
}