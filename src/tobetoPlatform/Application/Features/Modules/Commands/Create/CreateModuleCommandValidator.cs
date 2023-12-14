using FluentValidation;

namespace Application.Features.Modules.Commands.Create;

public class CreateModuleCommandValidator : AbstractValidator<CreateModuleCommand>
{
    public CreateModuleCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.SoftwareLanguageId).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
    }
}