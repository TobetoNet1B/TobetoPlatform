using FluentValidation;

namespace Application.Features.SoftwareLanguages.Commands.Update;

public class UpdateSoftwareLanguageCommandValidator : AbstractValidator<UpdateSoftwareLanguageCommand>
{
    public UpdateSoftwareLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}