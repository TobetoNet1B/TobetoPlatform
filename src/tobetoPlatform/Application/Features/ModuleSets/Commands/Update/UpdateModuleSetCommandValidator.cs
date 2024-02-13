using FluentValidation;

namespace Application.Features.ModuleSets.Commands.Update;

public class UpdateModuleSetCommandValidator : AbstractValidator<UpdateModuleSetCommand>
{
    public UpdateModuleSetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.EducationType).NotEmpty();
        RuleFor(c => c.CourseLevel).NotEmpty();
        RuleFor(c => c.Topic).NotEmpty();
        RuleFor(c => c.SoftwareLanguageId).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.ActivityStatus).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.EstimatedTime).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.ModuleTypeId).NotEmpty();
    }
}