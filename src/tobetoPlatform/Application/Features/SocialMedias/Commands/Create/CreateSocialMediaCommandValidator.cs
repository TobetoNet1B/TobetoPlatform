using FluentValidation;

namespace Application.Features.SocialMedias.Commands.Create;

public class CreateSocialMediaCommandValidator : AbstractValidator<CreateSocialMediaCommand>
{
    public CreateSocialMediaCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Icon).NotEmpty();
        RuleFor(c => c.SocialMediaUrl).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}