using FluentValidation;

namespace Application.Features.TobetoContacts.Commands.Update;

public class UpdateTobetoContactCommandValidator : AbstractValidator<UpdateTobetoContactCommand>
{
    public UpdateTobetoContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FullName).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.IsReaded).NotEmpty();
    }
}