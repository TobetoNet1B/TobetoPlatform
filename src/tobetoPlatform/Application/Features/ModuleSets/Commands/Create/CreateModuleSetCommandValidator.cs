using FluentValidation;

namespace Application.Features.ModuleSets.Commands.Create;

public class CreateModuleSetCommandValidator : AbstractValidator<CreateModuleSetCommand>
{
    public CreateModuleSetCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.SoftwareLanguageId).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
    }
}