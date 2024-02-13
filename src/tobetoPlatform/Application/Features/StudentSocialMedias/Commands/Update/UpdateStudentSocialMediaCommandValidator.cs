using FluentValidation;

namespace Application.Features.StudentSocialMedias.Commands.Update;

public class UpdateStudentSocialMediaCommandValidator : AbstractValidator<UpdateStudentSocialMediaCommand>
{
    public UpdateStudentSocialMediaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.SocialMediaId).NotEmpty();
        RuleFor(c => c.SocialMediaUrl).NotEmpty();
    }
}