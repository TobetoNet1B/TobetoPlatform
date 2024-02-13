using FluentValidation;

namespace Application.Features.StudentSocialMedias.Commands.Create;

public class CreateStudentSocialMediaCommandValidator : AbstractValidator<CreateStudentSocialMediaCommand>
{
    public CreateStudentSocialMediaCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.SocialMediaId).NotEmpty();
        RuleFor(c => c.SocialMediaUrl).NotEmpty();
    }
}