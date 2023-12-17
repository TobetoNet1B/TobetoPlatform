using FluentValidation;

namespace Application.Features.ModuleSets.Commands.Update;

public class UpdateModuleSetCommandValidator : AbstractValidator<UpdateModuleSetCommand>
{
    public UpdateModuleSetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.SoftwareLanguageId).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
    }
}