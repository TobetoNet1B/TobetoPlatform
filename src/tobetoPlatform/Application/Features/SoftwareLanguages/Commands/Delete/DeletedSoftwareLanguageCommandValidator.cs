using FluentValidation;

namespace Application.Features.SoftwareLanguages.Commands.Delete;

public class DeleteSoftwareLanguageCommandValidator : AbstractValidator<DeleteSoftwareLanguageCommand>
{
    public DeleteSoftwareLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}